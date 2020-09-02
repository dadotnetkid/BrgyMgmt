//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrgyMgmt.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EstablishmentLog
    {
        public long EstablishmentLogId { get; set; }
        public Nullable<int> ResidentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BarangayName { get; set; }
        public Nullable<int> BarangayId { get; set; }
        public Nullable<int> BarangayTownCity { get; set; }
        public decimal Temperature { get; set; }
        public System.DateTime LogDateTime { get; set; }
        public string Phone { get; set; }
        public Nullable<int> EstablishmentId { get; set; }
    
        public virtual Establishment Establishment { get; set; }
    }
}