using System;
using Emaratech.Services.Zajel.DataAccess.ZajelServiceExternal;

namespace Emaratech.Services.Zajel.DataAccess
{
    public static class VisionDataRequestDTOHelpers
    {
        // Implemented equality as extension method since this is partical class from .wsdl proxy. 
        // Implementing equality might discrupt working of .wsdl client (proxy) that his class belongs to. 
        // Unlikely, perhaps worth implementing equality later on (since VisionDataRequestDTO is partial, it is possible). 
        public static bool IsEqual(this VisionDataRequestDTO me, VisionDataRequestDTO other)
        {
            if (ReferenceEquals(null, me) && ReferenceEquals(null, other)) return true;
            if (ReferenceEquals(null, other) || ReferenceEquals(null, me)) return false;
            if (ReferenceEquals(me, other)) return true;

            return (
                string.Equals(me.Address, other.Address) &&
                string.Equals(me.Application, other.Application) &&
                string.Equals(me.Area, other.Area) &&
                string.Equals(me.ApplicationType, other.ApplicationType) &&
                string.Equals(me.ContactNo, other.ContactNo) &&
                string.Equals(me.DeliveryMode, other.DeliveryMode) &&
                me.ProductType == other.ProductType &&
                string.Equals(me.FileNo, other.FileNo) &&
                Object.Equals(me.ExtensionData, other.ExtensionData) &&
                string.Equals(me.LandLineNo, other.LandLineNo) &&
                string.Equals(me.ODRStatus, other.ODRStatus) &&                
                string.Equals(me.POBOX, other.POBOX) &&
                string.Equals(me.SponcerName, other.SponcerName));
        }
        
    }
}