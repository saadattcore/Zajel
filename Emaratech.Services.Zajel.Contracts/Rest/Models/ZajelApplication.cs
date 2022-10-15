using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using SwaggerWcf.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models
{
    [SwaggerWcfDefinition(Name = "ZajelApplication")]
    [DataContract]
    public class ZajelApplication
    {
        [DataMember(Name = "UniqueId")]
        public string UniqueId { get; set; }

        [DataMember(Name = "Awb")]
        public string Awb { get; set; }

        [DataMember(Name = "Status")]
        public string Status { get; set; }

        [DataMember(Name = "SystemId")]
        public string SystemId { get; set; }

        [DataMember(Name = "ApplicationId")]
        public string ApplicationId { get; set; }

        [DataMember(Name = "ContactNo")]
        public string ContactNo { get; set; }

        [DataMember(Name = "Landline")]
        public string Landline { get; set; }

        [DataMember(Name = "SponsorName")]
        public string SponsorName { get; set; }

        [DataMember(Name = "Area")]
        public string Area { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "PoBox")]
        public string PoBox { get; set; }

        [DataMember(Name = "OdrStatus")]
        public string OdrStatus { get; set; }

        [DataMember(Name = "DeliveryMode")]
        public string DeliveryMode { get; set; }

        [DataMember(Name = "ApplicationType")]
        public string ApplicationType { get; set; }

        [DataMember(Name = "FileNo")]
        public string FileNo { get; set; }

        [DataMember(Name = "ProductType")]
        public string ProductType { get; set; }
        [DataMember(Name = "CreatedDate")]
        public string Created { get; set; }


        [DataMember(Name = "ApplicationStatus")]
        public string ApplicationStatus { get; set; }
        [DataMember(Name = "PaymentDate")]
        public string PaymentDate { get; set; }
        [DataMember(Name = "ApplicantName")]
        public string ApplicantName { get; set; }
        [DataMember(Name = "ApplicantNameArabic")]
        public string ApplicantNameArabic { get; set; }
        [DataMember(Name = "PassportNo")]
        public string PassportNo { get; set; }
        [DataMember(Name = "Nationality")]
        public string Nationality { get; set; }
        [DataMember(Name = "NationalityArabic")]
        public string NationalityArabic { get; set; }
        [DataMember(Name = "SponsorNameArabic")]
        public string SponsorNameArabic { get; set; }
        [DataMember(Name = "SponsorFileNo")]
        public string SponsorFileNo { get; set; }
        [DataMember(Name = "TransactionNo")]
        public string TransactionNo { get; set; }

        [DataMember(Name = "ServiceNameArabic")]
        public string ServiceNameArabic { get; set; }
        [DataMember(Name = "ServiceName")]
        public string ServiceName { get; set; }
        [DataMember(Name = "Mobile")]
        public string Mobile { get; set; }
        [DataMember(Name = "Email")]
        public string Email { get; set; }
    }

}
