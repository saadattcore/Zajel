using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models
{

    [DataContract]
    public class SearchModel
    {    
        [DataMember]
        public string ApplicationNumber { get; set; }
        [DataMember]
        public string AWBNumber { get; set; }
        [DataMember]
        public DateTime? FromDate { get; set; }
        [DataMember]
        public DateTime? ToDate { get; set; }
        [DataMember]
        public string DeliveryStatus { get; set; }
    }
}
