//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCReleaseManagementProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LogIn
    {
        [Required]
        [RegularExpression("[a-zA-Z]+")]
        public string userId { get; set; }
        [Required]
        public string password { get; set; }

        public string role { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
