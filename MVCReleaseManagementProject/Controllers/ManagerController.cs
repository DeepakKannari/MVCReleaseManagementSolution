﻿using MVCReleaseManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCReleaseManagementProject.Controllers
{
    public class ManagerController : Controller
    {
        releaseProjectEntities dbContext = new releaseProjectEntities();
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addProject()
        {
            projectViewModel projectView = new projectViewModel();
            projectView.populatelist();
            ViewBag.managers = projectView.listofprojectmanagers;
            ViewBag.teamleads = projectView.listOfTeamLead;
            return View(projectView);   
        }

        [HttpPost]
        public ActionResult addProject(projectViewModel project_)
        {
            project formvalues = project_.getprojectvalues();
            dbContext.projects.Add(formvalues);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult approveProject(int id)
        {
            var result = dbContext.projects.FirstOrDefault(s=>s.Id.Equals(id));
            
            if (result != null)
            {
                result.projectStatus = "approved";
                dbContext.SaveChanges();
                var projectTable = dbContext.projects.Select(s => s);
                return View(projectTable);
            }

            ViewBag.id = id;
            return View();
        }

        public ActionResult viewProject()
        {
            var result = dbContext.projects.Select(s => s);

            return View(result);
                       
        }
        public ActionResult approveModule(int id)
        {
            var result = dbContext.project_modules.FirstOrDefault(s => s.id.Equals(id));

            if (result != null)
            {
                result.module_status = "approved";
                dbContext.SaveChanges();
                var projectTable = dbContext.project_modules.Select(s => s);
                return View(projectTable);
            }
            ViewBag.id = id;
            return View();

           
        }

        public ActionResult viewModule()
        {
            var result = dbContext.project_modules.Select(s => s);

            return View(result);

        }
    }
}