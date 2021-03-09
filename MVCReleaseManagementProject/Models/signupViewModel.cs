using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCReleaseManagementProject.Models
{
    public class signupViewModel
    {
        [Required]
        [RegularExpression("[a-zA-Z]+")]
        public string Id { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z ]+")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9]+")]
        public string password { get; set; }
        [Required]
        public string role { get; set; }
    }
}