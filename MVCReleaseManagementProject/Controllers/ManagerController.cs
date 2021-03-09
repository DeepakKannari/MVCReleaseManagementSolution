using MVCReleaseManagementProject.Models;
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
            ViewBag.status = projectView.listOfStatus;
            return View(projectView);   
        }

        [HttpPost]
        public ActionResult addProject(projectViewModel project_)
        {
            if (!ModelState.IsValid)
            {
                projectViewModel projectView = new projectViewModel();
                projectView.populatelist();
                ViewBag.managers = projectView.listofprojectmanagers;
                ViewBag.teamleads = projectView.listOfTeamLead;
                ViewBag.status = projectView.listOfStatus;
                return View();
                //project formvalues = project_.getprojectvalues();
                //dbContext.projects.Add(formvalues);
                //dbContext.SaveChanges();
                //return RedirectToAction("viewProject");
            }
            else
            {
                project formvalues = project_.getprojectvalues();
                dbContext.projects.Add(formvalues);
                dbContext.SaveChanges();
                return RedirectToAction("viewProject");
            }
        }

        public ActionResult approveProject(int id)
        {
            
            
                var result = dbContext.projects.FirstOrDefault(s => s.Id.Equals(id));

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

        public ActionResult viewcompleted()
        {
            var result = dbContext.projects.Where(s=>s.projectStatus.Equals("completed")).Select(s => s);

            return View(result);

        }

        public ActionResult viewapproved()
        {
            var result = dbContext.projects.Where(s => s.projectStatus.Equals("approved")).Select(s => s);

            return View(result);
        }
        public ActionResult approveModule(int id)
        {
            var result = dbContext.project_modules.FirstOrDefault(s => s.id.Equals(id));

            if (result != null)
            {
                result.module_status = "approved";
                dbContext.SaveChanges();
                //var projectTable = dbContext.project_modules.Select(s => s);
                return RedirectToAction("viewapprovedModules");
            }
            ViewBag.id = id;
            return View();

           
        }

        public ActionResult viewCompletedModule()
        {
            var result = dbContext.project_modules.Where(s => s.module_status.Equals("completed")).Select(s => s);

            return View(result);

        }

        public ActionResult viewapprovedModules()
        {
            var result = dbContext.project_modules.Where(s => s.module_status.Equals("approved")).Select(s => s);

            return View(result);
        }

        public ActionResult viewModule()
        {
            var result = dbContext.project_modules.Select(s => s);

            return View(result);

        }
    }
}