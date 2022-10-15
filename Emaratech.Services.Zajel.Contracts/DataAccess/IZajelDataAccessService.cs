using System.Collections.Generic;
using System.ServiceModel;
using Emaratech.Services.WcfCommons.Faults.Models;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Awb;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using ImpromptuInterface;
using Emaratech.Services.Common.Models;
using Emaratech.Services.Zajel.Entities;
using Emaratech.Services.Zajel.Contracts.Rest.Models;

namespace Emaratech.Services.Zajel.Contracts.DataAccess
{
    [ServiceContract]
    [UseNamedArgument]
    public interface IZajelDataAccessService
    {

        [OperationContract]
        [FaultContract(typeof(ErrorModel))]
        SendListResponse SendList(ApplicationInfoList applicationInfoList);

        [OperationContract]
        [FaultContract(typeof(ErrorModel))]
        string Send(ApplicationInfo applicationInfo);

        [OperationContract]
        [FaultContract(typeof(ErrorModel))]
        IList<ZajelStatus> Awb(IList<string> argUniqueIdsList);

        [OperationContract]
        [FaultContract(typeof(ErrorModel))]
        void BatchExport(int itemCount);

        [OperationContract]
        [FaultContract(typeof(ErrorModel))]
        void BatchStatusUpdate(int itemCount);

        [OperationContract]
        [FaultContract(typeof(ErrorModel))]
        PagingResponse<ZajelApplication> GetList(PagingRequest pagingRequest);
        [OperationContract]
        [FaultContract(typeof(ErrorModel))]
        PagingResponse<ZajelApplication> GetZajelApplicationList(PagingRequest<SearchModel> pagingRequest);
        List<ZajelApplication> ZajelApplications(List<string> applicationIds);
    }
}
