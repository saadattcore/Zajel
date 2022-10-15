using System.Runtime.Serialization;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models.Send
{
    [DataContract]
    public enum ProductTypeOptions
    {
        [EnumMember(Value = "39")]
        EntryPermitSingle = 39,
        [EnumMember(Value = "40")]
        Residence = 40,
        [EnumMember(Value = "41")]
        EntryPermitDouble = 41
    }
}