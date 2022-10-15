using System;

namespace Emaratech.Services.Zajel.Entities
{
    public partial class ZAJELINTEGRATION : IEquatable<ZAJELINTEGRATION>
    {
        public bool Equals(ZAJELINTEGRATION other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ID, other.ID) 
                && string.Equals(SYSTEM_KEY, other.SYSTEM_KEY) 
                && string.Equals(APPLICATION_ID, other.APPLICATION_ID) 
                && string.Equals(CONTACTNO, other.CONTACTNO) 
                && string.Equals(LANDLINENO, other.LANDLINENO) 
                && string.Equals(SPONSORNAME, other.SPONSORNAME) 
                && string.Equals(AREA, other.AREA) 
                && string.Equals(ADDRESS, other.ADDRESS) 
                && string.Equals(POBOX, other.POBOX) 
                && string.Equals(ODRSTATUS, other.ODRSTATUS) 
                && DELIVERYMODE == other.DELIVERYMODE 
                && string.Equals(APPLICATIONTYPE, other.APPLICATIONTYPE) 
                && string.Equals(FILENO, other.FILENO) 
                && PRODUCTTYPE == other.PRODUCTTYPE 
                && string.Equals(AIRWAYBILLID, other.AIRWAYBILLID) 
                && string.Equals(RESPONSECURRENTSTATUS, other.RESPONSECURRENTSTATUS) 
                && string.Equals(RESPONSEDESCRIPTION, other.RESPONSEDESCRIPTION) 
                && string.Equals(RESPONSERESULT, other.RESPONSERESULT);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ZAJELINTEGRATION) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ID != null ? ID.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (SYSTEM_KEY != null ? SYSTEM_KEY.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (APPLICATION_ID != null ? APPLICATION_ID.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CONTACTNO != null ? CONTACTNO.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LANDLINENO != null ? LANDLINENO.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (SPONSORNAME != null ? SPONSORNAME.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AREA != null ? AREA.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ADDRESS != null ? ADDRESS.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (POBOX != null ? POBOX.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ODRSTATUS != null ? ODRSTATUS.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ DELIVERYMODE.GetHashCode();
                hashCode = (hashCode*397) ^ (APPLICATIONTYPE != null ? APPLICATIONTYPE.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FILENO != null ? FILENO.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ PRODUCTTYPE.GetHashCode();
                hashCode = (hashCode*397) ^ (AIRWAYBILLID != null ? AIRWAYBILLID.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (RESPONSECURRENTSTATUS != null ? RESPONSECURRENTSTATUS.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (RESPONSEDESCRIPTION != null ? RESPONSEDESCRIPTION.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (RESPONSERESULT != null ? RESPONSERESULT.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ZAJELINTEGRATION left, ZAJELINTEGRATION right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ZAJELINTEGRATION left, ZAJELINTEGRATION right)
        {
            return !Equals(left, right);
        }
    }
}