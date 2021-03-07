using MVCReleaseManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementProject.Controllers
{
    
    public class TesterController : Controller
    {
        releaseProjectEntities dbContext = new releaseProjectEntities();
        static string testerId;
        // GET: Tester
        public ActionResult Index()
        {
            testerId = TempData["testerId"] as string;
            ViewBag.tester = testerId;
            return View();
        }

        public ActionResult viewModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;
            var result = dbContext.project_modules.Where(s => s.tester.Equals(testerId));

            return View(result);

        }

        public ActionResult viewbugs()
        {
            //var result = dbContext.bugs.Where(s => s.tester.Equals("geo"));

            return View(/*result*/);

        }
        public ActionResult raiseABug()
        {
            bugViewModel bugView = new bugViewModel();
            bugView.populatelist(testerId);
            return View();
        }
        [HttpPost]
        
        public ActionResult raiseABug(bugViewModel bugView_)
        {
            //bug bugView = bugView_.getbugValues();
            //dbContext.bugs.Add(bugView);
            //var result = dbContext.project_modules.FirstOrDefault(s => s.Id.Equals(id));
            return RedirectToAction("view");
        }


    }
}