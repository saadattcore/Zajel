using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models
{
    [DataContract]
   public class SearchRequest:SearchModel
    {
        [DataMember]
       public  string PageNumber { get; set; }
        [DataMember]
       public string ItemsCount { get; set; }
    }
}
