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
    
    public partial class ApplicationSetting
    {
        public int ApplicationSettingsId { get; set; }
        public string ApplicationSettingsName { get; set; }
        public string ApplicationSettingsValue { get; set; }
        public string ApplicationSettingsCategory { get; set; }
        public Nullable<short> ApplicationSettingsSortOrder { get; set; }
    }
}