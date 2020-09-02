using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrgyMgmt.Web.Models {
    public class LoginModel {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
    public class ExternalLoginListModel {
        public string ReturnUrl { get; set; }
    }
    public class LoginStatusModel {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime? HireDate { get; set; }
        public byte[] Photo { get; set; }
    }
    public class License {
        [Required]
        [Display(Name = "Registered Email")]
        [EmailAddress]
        public string RegisteredEmail { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "LicenseKey")]
        public string LicenseKey { get; set; }
    }
}