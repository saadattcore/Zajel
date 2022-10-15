using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Threading.Tasks;
using AutoMapper;
using Emaratech.Services.Common.Models;
using Emaratech.Services.WcfCommons.Client;
using Emaratech.Services.Zajel.Contracts.DataAccess;
using Emaratech.Services.Zajel.Contracts.Rest;
using Emaratech.Services.Zajel.Contracts.Rest.Models;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Awb;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using SwaggerWcf.Attributes;

namespace Emaratech.Services.Zajel
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [SwaggerWcf("/")]
    public class ZajelService :IZajelService
    {
        private IMapper Mapper { get; }
        private WcfClient<IZajelDataAccessService> ZajelDataAccessService { get; }


        public ZajelService(IMapper mapper, WcfClient<IZajelDataAccessService> zajelDataAccessService)
        {
            Mapper = mapper;
            ZajelDataAccessService = zajelDataAccessService;
        }

        public void OptionsHandler()
        {
        }

        public SendListResponse SendList(ApplicationInfoList applicationInfoList)
        {
            return ZajelDataAccessService.Process(x => x.SendList(applicationInfoList));
        }

        public string Send(ApplicationInfo applicationInfo)
        {
            return ZajelDataAccessService.Process(x => x.Send(applicationInfo));
        }

        public IList<ZajelStatus> Awb(UniqueIdListWrapper argUniqueIdsList)
        {
            return ZajelDataAccessService.Process(x => x.Awb(argUniqueIdsList.UniqueIdsList));           
        }

        public void BatchExport(int itemCount)
        {
            ZajelDataAccessService.Process(x => x.BatchExport(itemCount));
        }

        public void BatchStatusUpdate(int itemCount)
        {
            ZajelDataAccessService.Process(x => x.BatchStatusUpdate(itemCount));
        }

        public PagingResponse<ZajelApplication> GetList(string pageNumber, string itemsCount)
        {
    
            var apps = ZajelDataAccessService.Process(x => x.GetList(PagingRequest.CreatePageRequest(pageNumber, itemsCount)));
            var response = PagingResponse<ZajelApplication>.CreateResponse(apps.Paging, apps.Data.ToList());

            return response;

        }
        PagingResponse<ZajelApplication> IZajelService.GetZajelApplicationList(SearchRequest searchrequest)
        {

            var searchmodel = new SearchModel { ApplicationNumber = searchrequest.ApplicationNumber, AWBNumber = searchrequest.AWBNumber, FromDate = searchrequest.FromDate, ToDate = searchrequest.ToDate, DeliveryStatus = searchrequest.DeliveryStatus };
            var apps = ZajelDataAccessService.Process(x => x.GetZajelApplicationList(PagingRequest.CreatePageRequest(searchmodel, searchrequest.PageNumber, searchrequest.ItemsCount)));
            var response = PagingResponse<ZajelApplication>.CreateResponse(apps.Paging, apps.Data.ToList());

            return response;
        }



        public async Task<List<ZajelApplication>> ZajelApplications(ApplicationIds applicationIds)
        {

            var zajelApps =  ZajelDataAccessService.Process(x => x.ZajelApplications(applicationIds.ApplicationIdsList));


            return zajelApps;
        }

    }
}
