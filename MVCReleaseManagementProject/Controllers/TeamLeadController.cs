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
        public ActionResult addModules()
        {
            moduleViewModel moduleview = new moduleViewModel();
            moduleview.populatelist();
            ViewBag.developers = moduleview.listofdevelopers;
            ViewBag.testers = moduleview.listOftesters;
            ViewBag.projectIds = moduleview.listOfProjectIds;
            return View(moduleview);
        }

        [HttpPost]
        public ActionResult addModules(moduleViewModel module_)
        {
            project_modules formvalues = module_.getProjectModuleValues();
            dbContext.project_modules.Add(formvalues);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }

    }
}