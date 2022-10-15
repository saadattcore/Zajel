using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using Emaratech.Services.WcfCommons.Cors;
using Emaratech.Services.Zajel.Contracts.Rest.Models;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Awb;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using ImpromptuInterface;
using SwaggerWcf.Attributes;
using Emaratech.Services.WcfCommons.Faults.Models;
using Emaratech.Services.Common.Models;
using System;
using System.Threading.Tasks;

namespace Emaratech.Services.Zajel.Contracts.Rest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IZajelService" in both code and config file together.
    [ServiceContract]
    [UseNamedArgument]
    public interface IZajelService : ICorsAwareRestWcfService
    {
        [SwaggerWcfTag("Zajel")]
        [SwaggerWcfPath("Get zajel applications", "Get all zajel applications")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Ok")]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Server-side error", true)]
        [OperationContract]
        [FaultContract(typeof(ErrorModel))]
        [WebInvoke(Method = "GET", UriTemplate = "/zajel/applications?pageNumber={pageNumber}&itemsCount={itemsCount}", RequestFormat = WebMessageFormat.Json)]
        PagingResponse<ZajelApplication> GetList(string pageNumber, string itemsCount);

        [SwaggerWcfTag("Zajel")]
        [SwaggerWcfPath("Search in all zajel applications", "Search in all zajel applications", "GetZajelApplicationList")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Ok")]
        [SwaggerWcfResponse(HttpStatusCode.Created)]
        [SwaggerWcfResponse(HttpStatusCode.Conflict, "Already exists", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Server-side error", true)]
        [WebInvoke(Method = "POST", UriTemplate = "zajel/search/applications", RequestFormat = WebMessageFormat.Json ,ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        PagingResponse<ZajelApplication> GetZajelApplicationList(SearchRequest searchRequest);

        [SwaggerWcfTag("Zajel")]
        [SwaggerWcfPath("Get Zajel Applications", "Get Zajel Applications", "GetZajelApplications")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Ok")]
        [SwaggerWcfResponse(HttpStatusCode.Created)]
        [SwaggerWcfResponse(HttpStatusCode.Conflict, "Already exists", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Server-side error", true)]
        [WebInvoke(Method = "POST", UriTemplate = "zajel/applications", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
       Task <List<ZajelApplication>> ZajelApplications(ApplicationIds applicationIds);




        [SwaggerWcfTag("Zajel")]
        [SwaggerWcfPath("Send, request application sending by zajel.", "Send, request application sending by zajel.", "Send")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Okay")]
        [SwaggerWcfResponse(HttpStatusCode.Created)]
        [SwaggerWcfResponse(HttpStatusCode.Conflict, "Already exists", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Server-side error", true)]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Client-side error (invalid input data)", true)]
        [WebInvoke(Method = "POST", UriTemplate = "/zajel/send", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string Send(ApplicationInfo applicationInfo);

        [SwaggerWcfTag("Zajel")]
        [SwaggerWcfPath("SendList, request sending of list of applications by zajel.", "Send, request sending list of application by zajel.", "SendList")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Okay")]
        [SwaggerWcfResponse(HttpStatusCode.Created)]
        [SwaggerWcfResponse(HttpStatusCode.Conflict, "Already exists", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Server-side error", true)]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Client-side error (invalid input data)", true)]
        [WebInvoke(Method = "POST", UriTemplate = "/zajel/sendlist", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        SendListResponse SendList(ApplicationInfoList applicationInfoList);


        [SwaggerWcfTag("Zajel")]
        [SwaggerWcfPath("Request zajel awb and status.", "Request zajel awb and status.", "Awb")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Okay")]
        [SwaggerWcfResponse(HttpStatusCode.Created)]
        [SwaggerWcfResponse(HttpStatusCode.Conflict, "Already exists", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Server-side error", true)]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Client-side error (invalid input data)", true)]
        [WebInvoke(Method = "POST", UriTemplate = "/zajel/awb", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IList<ZajelStatus> Awb(UniqueIdListWrapper argUniqueIdsList);

        [SwaggerWcfTag("ZajelBatch")]
        [SwaggerWcfPath("Export application delivery info to zajel.", "Export application delivery info to zajel.", "BatchExport")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Okay")]
        [SwaggerWcfResponse(HttpStatusCode.Created)]
        [SwaggerWcfResponse(HttpStatusCode.Conflict, "Already exists", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Server-side error", true)]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Client-side error (invalid input data)", true)]
        [WebInvoke(Method = "POST", UriTemplate = "/zajel/batch/export", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void BatchExport(int itemCount);

        [SwaggerWcfTag("ZajelBatch")]
        [SwaggerWcfPath("Export delivery applications to zajel.", "Export delivery applications to zajel.", "BatchStatusUpdate")]
        [SwaggerWcfResponse(HttpStatusCode.OK, "Okay")]
        [SwaggerWcfResponse(HttpStatusCode.Created)]
        [SwaggerWcfResponse(HttpStatusCode.Conflict, "Already exists", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Server-side error", true)]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Client-side error (invalid input data)", true)]
        [WebInvoke(Method = "POST", UriTemplate = "/zajel/batch/status", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void BatchStatusUpdate(int itemCount);

    }
}
