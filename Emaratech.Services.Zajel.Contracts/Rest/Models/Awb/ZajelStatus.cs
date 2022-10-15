using System.Runtime.Serialization;
using SwaggerWcf.Attributes;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models.Awb
{
    [SwaggerWcfDefinition(Name = "ZajelStatus")]
    [DataContract]
    public class ZajelStatus
    {
        [DataMember(Name = "UniqueId")]
        public string UniqueId { get; set; }

        [DataMember(Name = "Awb")]
        public string Awb { get; set; }

        [DataMember(Name = "Status")]
        public string Status { get; set; }
    }
}