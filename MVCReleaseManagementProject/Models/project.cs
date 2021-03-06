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

    
    public partial class project
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            this.project_modules = new HashSet<project_modules>();
        }



        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Expected Start Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> E_start_Date { get; set; }
        [Required]
        [Display(Name = "Expected End Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> E_end_Date { get; set; }
        [Required]
        [Display(Name = "Actual Start Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> a_start_date { get; set; }
        [Required]
        [Display(Name = "Actual End Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> a_end_date { get; set; }
        [Required]
        [Display(Name = "Manager")]
        public string projectManager { get; set; }
        [Required]
        [Display(Name = "Project Status")]
        public string projectStatus { get; set; }
        [Required]
        [Display(Name = "Team Lead")]
        public string TeamLead { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project_modules> project_modules { get; set; }

        
    }
}
