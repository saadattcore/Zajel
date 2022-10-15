using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models
{
    [DataContract]
    public class ApplicationIds
    {
        [DataMember]
        public List<string> ApplicationIdsList { get; set; }
    }
}
