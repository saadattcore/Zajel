using System;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;

namespace Emaratech.Services.Zajel.DataAccess
{
    public static class MapperConfigurationUtils
    {
        public static DeliveryModeOptions ToDeliveryModeOptions(this Nullable<decimal> arg)
        {
            DeliveryModeOptions retValue;

            if (arg.HasValue)
            {
                retValue = (DeliveryModeOptions)arg.Value;
                if (!Enum.IsDefined(typeof(DeliveryModeOptions), retValue))
                {
                    //throw new ArgumentOutOfRangeException($"can't convert argument {arg} to DeliverModeOptions");

                    return DeliveryModeOptions.None;
                }
            }
            else
            {
                //throw new ArgumentOutOfRangeException($"can't convert null to DeliverModeOptions");

                return DeliveryModeOptions.None;
                
            }

            return retValue;
        }

        public static string ToDeliveryModeOptionsAsString(this Nullable<decimal> arg)
        {
            DeliveryModeOptions retValue = arg.ToDeliveryModeOptions();
            return retValue.ToString();
        }
    }
}