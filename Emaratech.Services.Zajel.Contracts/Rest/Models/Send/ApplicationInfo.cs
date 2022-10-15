using System;
using System.Runtime.Serialization;
using SwaggerWcf.Attributes;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models.Send
{
    [SwaggerWcfDefinition(Name = "ApplicationInfo")]
    [DataContract]
    public class ApplicationInfo : IEquatable<ApplicationInfo>
    {
        public bool Equals(ApplicationInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(SystemId, other.SystemId) &&
                   string.Equals(ApplicationId, other.ApplicationId) &&
                   string.Equals(ContactNo, other.ContactNo) &&
                   string.Equals(Landline, other.Landline) &&
                   string.Equals(SponsorName, other.SponsorName) &&
                   string.Equals(Area, other.Area) &&
                   string.Equals(Address, other.Address) &&
                   string.Equals(PoBox, other.PoBox) &&
                   string.Equals(OdrStatus, other.OdrStatus) &&
                   DeliveryMode == other.DeliveryMode &&
                   string.Equals(ApplicationType, other.ApplicationType) &&
                   string.Equals(FileNo, other.FileNo) &&
                   ProductType == other.ProductType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ApplicationInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (SystemId != null ? SystemId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ApplicationId != null ? ApplicationId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ContactNo != null ? ContactNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Landline != null ? Landline.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (SponsorName != null ? SponsorName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Area != null ? Area.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Address != null ? Address.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PoBox != null ? PoBox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OdrStatus != null ? OdrStatus.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) DeliveryMode;
                hashCode = (hashCode*397) ^ (ApplicationType != null ? ApplicationType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FileNo != null ? FileNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) ProductType;
                return hashCode;
            }
        }

        public static bool operator ==(ApplicationInfo left, ApplicationInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ApplicationInfo left, ApplicationInfo right)
        {
            return !Equals(left, right);
        }

        #region Data members
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
        public DeliveryModeOptions DeliveryMode { get; set; }

        [DataMember(Name = "ApplicationType")]
        public string ApplicationType { get; set; }

        [DataMember(Name = "FileNo")]
        public string FileNo { get; set; }

        [DataMember(Name = "ProductType")]
        public ProductTypeOptions ProductType { get; set; }
        #endregion



    }

}
