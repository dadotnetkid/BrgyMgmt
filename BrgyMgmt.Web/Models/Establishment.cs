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
    
    public partial class Establishment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Establishment()
        {
            this.EstablishmentLogs = new HashSet<EstablishmentLog>();
        }
    
        public int EstablishmentId { get; set; }
        public string EstablishmentName { get; set; }
        public string EstablishmentAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstablishmentLog> EstablishmentLogs { get; set; }
    }
}
