using System.Runtime.Serialization;

namespace Emaratech.Services.Zajel.Contracts.Rest.Models.Send
{
    [DataContract]
    public enum DeliveryModeOptions
    {
        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "St")]
        St =1,

        [EnumMember(Value = "Dt")]
        Dt =2


    }
}