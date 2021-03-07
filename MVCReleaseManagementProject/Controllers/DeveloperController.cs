using MVCReleaseManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCReleaseManagementProject.Controllers
{
    public class DeveloperController : Controller
    {
        releaseProjectEntities dbContext = new releaseProjectEntities();
        static string developerId = "marvel";
        // GET: Developer
        public ActionResult Index()
        {
            if (TempData.ContainsKey("developer"))
            {
                developerId = TempData["developer"] as string;
                ViewBag.tester = developerId;
                return RedirectToAction("viewModule");
            }
            else
            {
                developerId = "marvel";
                return RedirectToAction("viewModule");
            }
           
        }

        public ActionResult viewModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;
           
            var result = dbContext.project_modules.Where(s => s.developer.Equals(developerId));

            return View(result);

        }

        public ActionResult viewCompletedModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;

            var result = dbContext.project_modules.Where(s => s.developer.Equals(developerId) && s.module_status.Equals("completed"));

            return View(result);

        }

        public ActionResult viewApprovedModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;

            var result = dbContext.project_modules.Where(s => s.developer.Equals(developerId) && s.module_status.Equals("approved"));

            return View(result);

        }

        public ActionResult viewDevelopmentModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;

            var result = dbContext.project_modules.Where(s => s.developer.Equals(developerId) && s.module_status.Equals("development"));

            return View(result);

        }

        public ActionResult viewtestingModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;

            var result = dbContext.project_modules.Where(s => s.developer.Equals(developerId) && s.module_status.Equals("testing"));

            return View(result);

        }

        public ActionResult completeModule(int id)
        {
            var result = dbContext.project_modules.FirstOrDefault(s => s.id.Equals(id));

            if (result != null)
            {
                result.module_status = "testing";
                dbContext.SaveChanges();
                var projectTable = dbContext.project_modules.Where(s => s.developer.Equals(developerId));
                //var projectTable = dbContext.project_modules.Select(s => s);
                return RedirectToAction("viewModule");
            }
            
            return View();


        }

        public ActionResult viewbugs()
        {
            //var result = dbContext.bugs.Where(s => s.tester.Equals("geo"));
            var joinresult = dbContext.bugs.Join(dbContext.project_modules,
                b => b.moduleId,
                p => p.id,
                (b, p) => new { b.id, b.moduleId, b.BugStatus, b.BugDescription, p.developer });
            var result = joinresult.Where(s => s.developer.Equals(developerId)).Select(b => new { id = b.id, moduleid = b.moduleId, bugstatus = b.BugStatus, bugdescription = b.BugDescription });
            List<bug> bugtable = new List<bug>();

            //for(int i=0;i<result.Count();i++)
            foreach (var item in result)
            {
                bug tempbug = new bug();
                tempbug.id = item.id;
                tempbug.moduleId = item.moduleid;
                tempbug.BugDescription = item.bugdescription;
                tempbug.BugStatus = item.bugstatus;
                bugtable.Add(tempbug);


            }
            return View(bugtable);

        }

    }
}