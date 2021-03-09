using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementProject.Models
{
    //[MetadataType(typeof(projectViewModel.Metadata))]
    public class projectViewModel
    {
        //private class Metadata
        //{
        //    [Required(ErrorMessage = "the projectManager is required field")]

        //    public string projectManager { get; set; }

        //    [Required(ErrorMessage = "the projectStatus is required field")]
        //    public string projectStatus { get; set; }

        //    [Required(ErrorMessage = "the TeamLead is required field")]
        //    public string TeamLead { get; set; }
        //};

        [Required]

        public int Id { get; set; }
        [Required]
        public Nullable<System.DateTime> E_start_Date { get; set; }
        [Required]
        public Nullable<System.DateTime> E_end_Date { get; set; }
        [Required]
        public Nullable<System.DateTime> a_start_date { get; set; }
        [Required]
        public Nullable<System.DateTime> a_end_date { get; set; }
        [Required]
        public string projectManager { get; set; }
        [Required]
        
        public string projectStatus { get; set; }
        [Required]
        public string TeamLead { get; set; }

        public List<SelectListItem> listofprojectmanagers = new List<SelectListItem>();
        public List<SelectListItem> listOfTeamLead = new List<SelectListItem>();
        public List<SelectListItem> listOfStatus = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "development", Value = "development"},
            new SelectListItem() { Text = "testing", Value = "testing"},
            new SelectListItem() { Text = "completed", Value = "completed"},
        };

        public projectViewModel()
        {
            //releaseProjectEntities dbcontext = new releaseProjectEntities();
            //var results = dbcontext.Employees.Where(s => s.Role.Equals("manager")).Select(s => new { id= s.Id , role=s.Role});
            //foreach (var item in results)
            //{
            //    listofprojectmanagers.Add(new SelectListItem() { Text = item.role, Value = item.id });
            //}
            //results = dbcontext.Employees.Where(s => s.Role.Equals("teamlead")).Select(s => new { id = s.Id, role = s.Role });
            //foreach (var item in results)
            //{
            //    listOfTeamLead.Add(new SelectListItem() { Text = item.role, Value = item.id });
            //}

        }

        public void populatelist()
        {
            releaseProjectEntities dbcontext = new releaseProjectEntities();
            var results = dbcontext.Employees.Where(s => s.Role.Equals("manager")).Select(s =>s.Id);
            foreach (var item in results)
            {
                this.listofprojectmanagers.Add(new SelectListItem() { Text = item, Value = item});
            }
            results = dbcontext.Employees.Where(s => s.Role.Equals("teamlead")).Select(s => s.Id);
            foreach (var item in results)
            {
                this.listOfTeamLead.Add(new SelectListItem() { Text = item, Value = item });
            }
        }

        public project getprojectvalues()
        {
            project tempproject = new project();
            tempproject.Id = this.Id;
            tempproject.E_start_Date = this.E_start_Date;
            tempproject.E_end_Date = this.E_end_Date;
            tempproject.a_start_date = this.a_start_date;
            tempproject.a_end_date = this.a_end_date;
            tempproject.projectManager = this.projectManager;
            tempproject.projectStatus = this.projectStatus;
            tempproject.TeamLead = this.TeamLead;
            return tempproject;
        }

       
    }
}