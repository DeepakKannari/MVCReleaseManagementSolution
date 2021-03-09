using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementProject.Models
{
    public class moduleViewModel
    {
        [Required]
        [Display(Name ="Project Id")]
        public Nullable<int> projectid { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z]+",ErrorMessage = "Use alphabets only")]
        [Display(Name ="Module Name")]
        public string name { get; set; }
        [Required]
        [Display(Name ="Module Id")]
        [Range(1,1000,ErrorMessage ="The Module id should be between 1-1000")]
        public int id { get; set; }
        [Required]
        [Display(Name = "Expected Start Date")]
        public Nullable<System.DateTime> e_start_date { get; set; }
        
        [Required]
        [Display(Name = "Expected End Date")]
        public Nullable<System.DateTime> e_end_date { get; set; }
        [Required]
        [Display(Name = "Actual Start Date")]
        public Nullable<System.DateTime> a_start_date { get; set; }
        [Required]
        [Display(Name ="Actual End Date")]
        public Nullable<System.DateTime> a_end_date { get; set; }
        [Required]
        [Display(Name ="Developer")]
        public string developer { get; set; }
        [Required]
        [Display(Name = "Tester")]
        public string tester { get; set; }
        [Required]
        [Display(Name = "Module Status")]
        public string module_status { get; set; }

        public List<SelectListItem> listofdevelopers = new List<SelectListItem>();
        public List<SelectListItem> listOftesters = new List<SelectListItem>();
        public List<SelectListItem> listOfProjectIds = new List<SelectListItem>();
        public List<SelectListItem> listOfStatus = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "development", Value = "development"},
            new SelectListItem() { Text = "testing", Value = "testing"},
            new SelectListItem() { Text = "completed", Value = "completed"},
        };

        public void populatelist()
        {
            releaseProjectEntities dbcontext = new releaseProjectEntities();
            var results = dbcontext.Employees.Where(s => s.Role.Equals("tester")).Select(s => s.Id);
            foreach (var item in results)
            {
                this.listOftesters.Add(new SelectListItem() { Text = item, Value = item });
            }
            results = dbcontext.Employees.Where(s => s.Role.Equals("developer")).Select(s => s.Id);
            foreach (var item in results)
            {
                this.listofdevelopers.Add(new SelectListItem() { Text = item, Value = item });
            }

           var pids = dbcontext.projects.Select(s=>s.Id);
            foreach (var item in pids)
            {
                this.listOfProjectIds.Add(new SelectListItem() { Text =item+"", Value = item+"" });
            }
        }

        public project_modules getProjectModuleValues()
        {
            project_modules tempproject = new project_modules();
            tempproject.projectid = this.projectid;
            tempproject.name = this.name;
            tempproject.id = this.id;
            tempproject.e_start_date = this.e_start_date;
            tempproject.e_end_date = this.e_end_date;
            tempproject.a_start_date = this.a_start_date;
            tempproject.a_end_date = this.a_end_date;
            tempproject.developer = this.developer;
            tempproject.tester = this.tester;
            tempproject.module_status = this.module_status;
            return tempproject;
        }




    }
}