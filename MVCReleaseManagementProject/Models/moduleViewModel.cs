using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementProject.Models
{
    public class moduleViewModel
    {
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

        public List<SelectListItem> listofdevelopers = new List<SelectListItem>();
        public List<SelectListItem> listOftesters = new List<SelectListItem>();
        public List<SelectListItem> listOfProjectIds = new List<SelectListItem>();

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