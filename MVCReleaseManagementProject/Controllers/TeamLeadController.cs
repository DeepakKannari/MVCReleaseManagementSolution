using MVCReleaseManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementProject.Controllers
{
    public class TeamLeadController : Controller
    {
        releaseProjectEntities dbContext = new releaseProjectEntities();
        // GET: TeamLead
        public ActionResult Index()
        {
            var result = dbContext.project_modules.Select(s=>s);
            if (result != null)
            {
                return View(result);
            }
            return View();
        }
        public ActionResult addModule()
        {
            moduleViewModel moduleview = new moduleViewModel();
            moduleview.populatelist();
            ViewBag.developers = moduleview.listofdevelopers;
            ViewBag.testers = moduleview.listOftesters;
            ViewBag.projectIds = moduleview.listOfProjectIds;
            return View(moduleview);
        }

        [HttpPost]
        public ActionResult addModule(moduleViewModel module_)
        {
            project_modules formvalues = module_.getProjectModuleValues();
            dbContext.project_modules.Add(formvalues);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult viewModule()
        {
            var result = dbContext.project_modules.Select(s => s);

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

    }
}