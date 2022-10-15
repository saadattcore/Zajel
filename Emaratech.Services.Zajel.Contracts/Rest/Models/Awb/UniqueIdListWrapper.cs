using System.Collections.Generic;
using System.Runtime.Serialization;
using SwaggerWcf.Attributes;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models.Awb
{
    [SwaggerWcfDefinition(Name = "UniqueIdListWrapper")]
    [DataContract]
    public class UniqueIdListWrapper
    {
        [DataMember(Name = "UniqueIdsList")]
        public List<string> UniqueIdsList { get; set; }
    }
}