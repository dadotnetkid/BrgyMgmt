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
    
    public partial class LetterTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LetterTemplate()
        {
            this.Certificates = new HashSet<Certificate>();
        }
    
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int TemplateType { get; set; }
        public string TemplateBody { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public short SortOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}