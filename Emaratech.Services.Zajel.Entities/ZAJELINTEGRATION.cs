//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emaratech.Services.Zajel.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZAJELINTEGRATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZAJELINTEGRATION()
        {
            this.STATUS = new HashSet<STATUS>();
        }
    
        public string ID { get; set; }
        public string SYSTEM_KEY { get; set; }
        public string APPLICATION_ID { get; set; }
        public string CONTACTNO { get; set; }
        public string LANDLINENO { get; set; }
        public string SPONSORNAME { get; set; }
        public string AREA { get; set; }
        public string ADDRESS { get; set; }
        public string POBOX { get; set; }
        public string ODRSTATUS { get; set; }
        public Nullable<decimal> DELIVERYMODE { get; set; }
        public string APPLICATIONTYPE { get; set; }
        public string FILENO { get; set; }
        public Nullable<decimal> PRODUCTTYPE { get; set; }
        public string AIRWAYBILLID { get; set; }
        public string RESPONSECURRENTSTATUS { get; set; }
        public string RESPONSEDESCRIPTION { get; set; }
        public string RESPONSERESULT { get; set; }
        public Nullable<System.DateTime> CREATED { get; set; }
        public Nullable<System.DateTime> LASTMODIFIED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STATUS> STATUS { get; set; }
    }
}
