using System.Collections.Generic;
using System.Runtime.Serialization;
using SwaggerWcf.Attributes;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models.Send
{
    [SwaggerWcfDefinition(Name = "ApplicationInfoList")]
    [DataContract]
    public class ApplicationInfoList
    {
        [DataMember(Name = "Content")]
        public List<ApplicationInfo> Content { get; set; }
    }

    [SwaggerWcfDefinition(Name = "SendListResponse")]
    [DataContract]
    public class SendListResponse
    {
        [DataMember(Name = "Content")]
        public Dictionary<string, string> Content { get; set; }
    }
}