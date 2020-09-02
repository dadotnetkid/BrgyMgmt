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
    
    public partial class MaintenanceTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaintenanceTable()
        {
            this.Complaints = new HashSet<Complaint>();
            this.Complaints1 = new HashSet<Complaint>();
            this.Complaints2 = new HashSet<Complaint>();
            this.HouseholdPropertyProductions = new HashSet<HouseholdPropertyProduction>();
            this.Clearances = new HashSet<Clearance>();
        }
    
        public int MaintenanceId { get; set; }
        public string MaintenanceEntryName { get; set; }
        public string MaintenanceTableType { get; set; }
        public int SortOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaints2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseholdPropertyProduction> HouseholdPropertyProductions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clearance> Clearances { get; set; }
    }
}
