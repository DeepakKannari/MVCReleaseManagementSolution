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
    
    public partial class bug
    {
        public int id { get; set; }
        public Nullable<int> moduleId { get; set; }
        public string BugDescription { get; set; }
        public string BugStatus { get; set; }
    
        public virtual project_modules project_modules { get; set; }
    }
}
