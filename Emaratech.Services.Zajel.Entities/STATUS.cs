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
    
    public partial class STATUS
    {
        public string ID { get; set; }
        public string ZAJELINTEGRATION_ID { get; set; }
        public string ZAJEL_STATUS { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
    
        public virtual ZAJELINTEGRATION ZAJELINTEGRATION { get; set; }
    }
}
