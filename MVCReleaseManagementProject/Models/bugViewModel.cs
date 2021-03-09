using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementProject.Models
{
    public class bugViewModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public Nullable<int> moduleId { get; set; }
        [Required]
        public string BugDescription { get; set; }
        [Required]
        public string BugStatus { get; set; }

        public List<SelectListItem> listofmoduleIds = new List<SelectListItem>();

        public void populatelist(string testerId)
        {
            releaseProjectEntities dbcontext = new releaseProjectEntities();
            var results = dbcontext.project_modules.Where(s => s.tester.Equals(testerId)&&s.module_status.Equals("testing")).Select(s => s.id);
            foreach (var item in results)
            {
                this.listofmoduleIds.Add(new SelectListItem() { Text = item+"", Value = item+"" });
            }
            
        }
        public bug getbugValues()
        {
            bug tempproject = new bug();
            tempproject.id = this.id;
            tempproject.moduleId = this.moduleId;
            tempproject.BugDescription = this.BugDescription;
            tempproject.BugStatus = this.BugStatus;

            return tempproject;
        }
    }

    
}
