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
   

    public partial class project_modules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project_modules()
        {
            this.bugs = new HashSet<bug>();
        }

       
        public Nullable<int> projectid { get; set; }
        
        public string name { get; set; }
       
        public int id { get; set; }
        
        public Nullable<System.DateTime> e_start_date { get; set; }
        
        public Nullable<System.DateTime> e_end_date { get; set; }
        
        public Nullable<System.DateTime> a_start_date { get; set; }
        
        public Nullable<System.DateTime> a_end_date { get; set; }
        
        public string developer { get; set; }
        
        public string tester { get; set; }
       
        public string module_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bug> bugs { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual project project { get; set; }
    }
}
