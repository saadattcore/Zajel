using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using AutoMapper;
using Castle.Core.Internal;
using Emaratech.DatabaseLayer;
using Emaratech.Services.Application.Api;
using Emaratech.Services.Application.Model;
using Emaratech.Services.Common.Models;
using Emaratech.Services.Zajel.Common;
using Emaratech.Services.Zajel.Contracts.DataAccess;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Awb;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using Emaratech.Services.Zajel.DataAccess.ZajelServiceExternal;
using Emaratech.Services.Zajel.Entities;
using log4net;
using Emaratech.Utilities;
using Emaratech.Services.Zajel.Contracts.Rest.Models;
using Emaratech.Services.WcfCommons.Faults.Models;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using Emaratech.Services.Zajel.DataAccess.src;

namespace Emaratech.Services.Zajel.DataAccess
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ZajelDataAccessService : IZajelDataAccessService
    {
        private SystemSettings SystemSettingsGetter { get; }
        private IApplicationApi AppApi { get; }
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }
        private ILog Logger { get; }
        private ZajelServiceExternal.IZ360Service ServiceClient { get; }

        public ZajelDataAccessService(IUnitOfWork unitOfWork, IMapper mapper,
            IRemoteServicesProxyFactory argRemoteServicesProxyFactory, ILog argLogger, ZajelServiceExternal.IZ360Service serviceClient)
        {
            SystemSettingsGetter = argRemoteServicesProxyFactory.CreateSystemSettings(Constants.DataAccess.UnifiedChannelSysId);
            AppApi = argRemoteServicesProxyFactory.CreateApplicationApi();
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            Logger = argLogger;
            ServiceClient = serviceClient;
        }

        public SendListResponse SendList(ApplicationInfoList applicationInfoList)

        {
            var content = new Dictionary<string, string>();

            foreach (var applicationInfo in applicationInfoList.Content)
            {
                try
                {
                    var uniqueID = Send(applicationInfo);
                    content.Add(applicationInfo.ApplicationId, uniqueID);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to save zajel application with {applicationInfo.ApplicationId}.", ex);
                    content.Add(applicationInfo.ApplicationId, null);
                }
            }

            return new SendListResponse() { Content = content };
        }


        public string Send(ApplicationInfo applicationInfo)
        {
            var zajelIntegrationRecord = Mapper.Map<ZAJELINTEGRATION>(applicationInfo);
            zajelIntegrationRecord.ID = System.Guid.NewGuid().ToString("N");
            zajelIntegrationRecord.CREATED = DateTime.Now;
            zajelIntegrationRecord.LASTMODIFIED = DateTime.Now;

            UnitOfWork.Repository<ZAJELINTEGRATION>().Insert(zajelIntegrationRecord);
            UnitOfWork.Save();

            return zajelIntegrationRecord.ID;
        }

        public IList<ZajelStatus> Awb(IList<string> argUniqueIdsList)
        {
            var retValue = UnitOfWork
                .Repository<ZAJELINTEGRATION>()
                .Get(x => argUniqueIdsList.Contains(x.ID))
                .Select(x => new ZajelStatus() { Status = x.RESPONSECURRENTSTATUS, UniqueId = x.ID, Awb = x.AIRWAYBILLID })
                .ToList();
            return retValue;
        }

        private bool IsApplicationApproved(RestApplicationStatusDetail appStatus)
        {
            return (appStatus != null && string.Equals(appStatus.StatusId, Constants.DataAccess.ApplicationApprovedStatus));

        }

        public void BatchExport(int itemCount)
        {
            Logger.Info($"BatchExport {itemCount} items");
            // Read data required for invocation
            var applicationsInRepository = FetchApplicationsInRepository();
            Logger.Info($"(BatchExport Func)Records found in zajelintegration table {applicationsInRepository.Count} and type of zajel client ={ServiceClient.GetType().Name}");
            if (applicationsInRepository.Count == 0) return;
            var applicationList = FilterOnlyApprovedAndSetFileNo(applicationsInRepository);

            // var remoteZajelService = new ZajelServiceExternal.Z360ServiceClient("BasicHttpBinding_IZ360Service");
            var zajelIntegrationRecords = Mapper.Map<List<VisionDataRequestDTO>>(applicationList);
            var rpcArg = CreateRpcArgument(zajelIntegrationRecords);

            var response = ServiceClient.VisionManifestBulkUploadRequest(rpcArg);
            if (response.Result == WSResult.Success)
            {
                UpdateRepositoryWithZajelResponse(applicationList, response);
            }
            else
            {
                Logger.Warn("Invocation of remote Zajel service failed with following result and description.");
                Logger.Warn(response.Result);
                Logger.Warn(response.ResultDesc);
            }

        }

        private List<ZAJELINTEGRATION> FilterOnlyApprovedAndSetFileNo(List<ZAJELINTEGRATION> applicationsInRepository)
        {
            var approvedOnly = applicationsInRepository
                .Select(x => new { APPLICATION = x, STATUS = GetApplicationStatus(x.APPLICATION_ID) })
                .Where(x => IsApplicationApproved(x.STATUS))
                .ToList();

            approvedOnly.ForEach(x => x.APPLICATION.FILENO = x.STATUS.VisaNumber);
            var applicationList = approvedOnly.Select(x => x.APPLICATION).ToList();
            return applicationList;
        }

        private RestApplicationStatusDetail GetApplicationStatus(string argApplicationId)
        {
            RestApplicationStatusDetail retValue = default(RestApplicationStatusDetail);

            try
            {
                Logger.Debug($"Fetch application status for application with Id {argApplicationId}");
                retValue = AppApi.GetApplicationStatusByApplicationId(argApplicationId);
            }
            catch (Exception ex)
            {
                Logger.Warn($"Unable to fetch application status for application with Id {argApplicationId}");
            }
            return retValue;
        }

        private List<ZAJELINTEGRATION> FetchApplicationsInRepository()
        {
            var applicationsInRepository = UnitOfWork
                .Repository<ZAJELINTEGRATION>()
                .Get(x => string.IsNullOrEmpty(x.AIRWAYBILLID))
                .ToList();
            return applicationsInRepository;
        }

        private void UpdateRepositoryWithZajelResponse(List<ZAJELINTEGRATION> applicationList, VisionResponceDTO response)
        {
            var @join = applicationList.Join(response.VisionDataResponceDTO,
                application => application.APPLICATION_ID,
                zajelResponse => zajelResponse.ApplicationID,
                (app, zResp) => new { Application = app, ZajelResponse = zResp });

            @join.ForEach(x =>
                {
                    this.Logger.Info($"Zajel batch export response. {x.ZajelResponse.AirwayBillID}, status = {x.ZajelResponse.CurrentStatus}, description = {x.ZajelResponse.Description}.");
                    x.Application.AIRWAYBILLID = x.ZajelResponse.AirwayBillID;
                    x.Application.RESPONSECURRENTSTATUS = x.ZajelResponse.CurrentStatus;
                    x.Application.RESPONSEDESCRIPTION = x.ZajelResponse.Description;
                }
            );

            try
            {
                SendAwbToVision(@join.Select(x => x.Application));
            }
            catch (Exception ex)
            {
                if (ex is FaultException<ErrorModel>)
                {
                    var fault = ex as FaultException<ErrorModel>;
                    this.Logger.Error($"Error while saving awb in vision. error message= {fault?.Detail?.ErrorMessage} and error code = {fault?.Detail?.ErrorCode}");
                }
                else
                {
                    this.Logger.Error($"Error while saving awb in vision. error message= {ex.Message}");
                }
                throw ex;
            }

            var duplicates = applicationList?.Join(response.VisionDataResponceDTO,
                a => a.APPLICATION_ID,
                r => r.AirwayBillID,
                (app, res) => new { Application = app, Response = res });

            duplicates = duplicates?.GroupBy(x => x.Application.ID)
                  .Select(x => x.First())
                  .ToList();

            duplicates?.ForEach(d => d.Application.RESPONSEDESCRIPTION = d.Response.Description);

            UnitOfWork.Save();

            var responseAppIdList = response.VisionDataResponceDTO.ToList().Select(x => x.ApplicationID);
            var difference = applicationList.Select(x => x.APPLICATION_ID).Except(responseAppIdList);
            difference.ForEach(x => Logger.Warn($"Zajel response is missing for application id {x}."));
        }

        private VisionRequestDTO CreateRpcArgument(List<VisionDataRequestDTO> zajelIntegrationRecords)
        {
            VisionRequestDTO argDto = new VisionRequestDTO()
            {
                BranchID = SystemSettingsGetter.ZajelBranchId,
                ClintID = SystemSettingsGetter.ZajelClientId,
                ExtensionData = null,
                UserID = new System.Guid(SystemSettingsGetter.ZajelUserId),
                visionDataRequestDTO = zajelIntegrationRecords.ToArray<VisionDataRequestDTO>()
            };
            return argDto;
        }

        public void BatchStatusUpdate(int itemCount)
        {
            //  var k = new ZajelServiceExternal.Z360ServiceClient("BasicHttpBinding_IZ360Service");
            var applicationList = UnitOfWork
                .Repository<ZAJELINTEGRATION>()
                .Get(x => !string.IsNullOrEmpty(x.AIRWAYBILLID) &&
                    !(Constants.DataAccess.FinalZajelStatusDelivered.Equals(x.RESPONSECURRENTSTATUS) ||
                      Constants.DataAccess.FinalZajelStatusFailed.Equals(x.RESPONSECURRENTSTATUS)))
                .ToList();

            Logger.Info($"(BatchStatusUpdate Func) Records found in zajelintegration table {applicationList.Count} and type of zajel client ={ServiceClient.GetType().Name}");

            applicationList.ForEach(x =>
            {
                try
                {
                    Logger.Info($"Trying to update status for application id {x.APPLICATION_ID}");
                    string zajelCurrentStatus = ServiceClient.VisionCurrentStatus(x.AIRWAYBILLID);

                    if (!zajelCurrentStatus.Equals(x.RESPONSECURRENTSTATUS))
                    {
                        LogApplicationStatus(zajelCurrentStatus, x.ID);
                        x.RESPONSECURRENTSTATUS = zajelCurrentStatus;
                        x.LASTMODIFIED = DateTime.Now;
                    }
                    Logger.Info($"Status for application id {x.APPLICATION_ID} will be update to {zajelCurrentStatus}");
                }
                catch (Exception ex)
                {
                    this.Logger.Error("Unable to retrieve zajel status. Exception details: ", ex);
                    this.Logger.Error($"Status for {x.AIRWAYBILLID} will not be updated.");
                }
            });
            UnitOfWork.Save();
        }

        public PagingResponse<ZajelApplication> GetList(Services.Common.Models.PagingRequest pagingRequest)
        {
            var allApps = UnitOfWork
               .Repository<ZAJELINTEGRATION>().Get();

            var totalCount = allApps.Count();
            var takeCount = pagingRequest.GetPageSize();
            var pageNumber = pagingRequest.GetPageNumber();

            var fieldPage = allApps
                .OrderBy(x => x.APPLICATION_ID)
                .Skip(pagingRequest.SkipCount)
                .Take(takeCount)
                .AsEnumerable()
                .Select(Mapper.Map<ZajelApplication>)
                .ToPagingResponse(pageNumber, totalCount);

            return fieldPage;
        }
       
        public PagingResponse<ZajelApplication> GetZajelApplicationList(PagingRequest<SearchModel> pagingRequest)
        {
            var allApps = UnitOfWork
               .Repository<ZAJELINTEGRATION>().Get();
            allApps = ZajelServiceHelper.FilterStatus(allApps);
            allApps = ZajelServiceHelper.GetCurrentApplication(allApps, pagingRequest);
            var totalCount = allApps.Count();
            var takeCount = pagingRequest.GetPageSize();
            var pageNumber = pagingRequest.GetPageNumber();

            var fieldPage = allApps
                .OrderBy(x => x.APPLICATION_ID)
                .Skip(pagingRequest.SkipCount)
                .Take(takeCount)
                .AsEnumerable()
                .Select(Mapper.Map<ZajelApplication>)
                .ToPagingResponse(pageNumber, totalCount);

            return fieldPage;
        }


        private void SendAwbToVision(IEnumerable<ZAJELINTEGRATION> zajelIntegrationList)
        {
            this.Logger.Info($"Sending applications with awb list to vision = {string.Join(",", zajelIntegrationList.Select(x => string.Format("appid = {0} awb = {1} ", x.APPLICATION_ID, x.AIRWAYBILLID)))}");

            var applicationAirwayBills = zajelIntegrationList.Select(x => new RestApplicationAirwayBill(x.APPLICATION_ID, x.AIRWAYBILLID)).ToList();
            RestApplicationAirwayBillRequired applicationAirwayBill = new RestApplicationAirwayBillRequired(applicationAirwayBills);
            var result = AppApi.InsertAirwayBillDetails(applicationAirwayBill);
        }

        private void LogApplicationStatus(string zajelCurrentStatus, string zajelIntegrationId)
        {
            STATUS dbStatus = new STATUS();
            dbStatus.ZAJEL_STATUS = zajelCurrentStatus;
            dbStatus.ID = System.Guid.NewGuid().ToString("N");
            dbStatus.ZAJELINTEGRATION_ID = zajelIntegrationId;
            dbStatus.CREATED_DATE = DateTime.Now;

            UnitOfWork.Repository<STATUS>().Insert(dbStatus);
        }

        public List<ZajelApplication> ZajelApplications(List<string> applicationIds)
        {
            var allApps = UnitOfWork
               .Repository<ZAJELINTEGRATION>().Get().Where(x => applicationIds.Any(s => x.APPLICATION_ID.Contains(s)));


            var result = allApps.Select(Mapper.Map<ZajelApplication>).ToList();
            return result;
        }
    }
}
