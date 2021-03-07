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
        static string testerId = "skrillie";
        // GET: Tester
        public ActionResult Index()
        {
            if (TempData.ContainsKey("testerId"))
            {
                testerId = TempData["testerId"] as string;
                ViewBag.tester = testerId;
                return RedirectToAction("viewModule");
            }
            else
            {
                testerId = "skrillie";
                return RedirectToAction("viewModule");
            }
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;
            //return View();
        }

        public ActionResult viewModule()
        {
            
            
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;
            var result = dbContext.project_modules.Where(s => s.tester.Equals(testerId));

            return View(result);

        }

        public ActionResult viewCompletedModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;

            var result = dbContext.project_modules.Where(s => s.tester.Equals(testerId) && s.module_status.Equals("completed"));

            return View(result);

        }

        public ActionResult viewApprovedModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;

            var result = dbContext.project_modules.Where(s => s.tester.Equals(testerId) && s.module_status.Equals("approved"));

            return View(result);

        }

        public ActionResult viewDevelopmentModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;

            var result = dbContext.project_modules.Where(s => s.tester.Equals(testerId) && s.module_status.Equals("development"));

            return View(result);

        }

        public ActionResult viewtestingModule()
        {
            //testerId = TempData["testerId"] as string;
            //ViewBag.tester = testerId;

            var result = dbContext.project_modules.Where(s => s.tester.Equals(testerId) && s.module_status.Equals("testing"));

            return View(result);

        }



        public ActionResult viewbugs()
        {
            //var result = dbContext.bugs.Where(s => s.tester.Equals("geo"));
            var joinresult = dbContext.bugs.Join(dbContext.project_modules,
                b => b.moduleId,
                p => p.id,
                (b, p) => new { b.id, b.moduleId, b.BugStatus, b.BugDescription,p.tester });
            var result = joinresult.Where(s=>s.tester.Equals(testerId)).Select(b=>new { id=b.id, moduleid=b.moduleId, bugstatus=b.BugStatus,bugdescription=b.BugDescription });
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
        public ActionResult raiseABug()
        {
            bugViewModel bugView = new bugViewModel();
            bugView.populatelist(testerId);
            return View();
        }
        [HttpPost]
        
        public ActionResult raiseABug(bugViewModel bugView_)
        {
            bug bugView = bugView_.getbugValues();
            dbContext.bugs.Add(bugView);
            dbContext.SaveChanges();

            return RedirectToAction("viewbugs");
        }

        public ActionResult closeBug(int id)
        {
            var result = dbContext.bugs.FirstOrDefault(s => s.id.Equals(id));
            if (result != null)
            {
                result.BugStatus = "closed";
                dbContext.SaveChanges();
                var bugtable = dbContext.bugs.Select(s => s);
                return RedirectToAction("viewbugs"); ;
              
            }
            return View();
        }

        public ActionResult completeModule(int id)
        {
            var result = dbContext.project_modules.FirstOrDefault(s => s.id.Equals(id));

            if (result != null)
            {
                result.module_status = "completed";
                dbContext.SaveChanges();
                var projectTable = dbContext.project_modules.Where(s => s.tester.Equals(testerId));
                //var projectTable = dbContext.project_modules.Select(s => s);
                return RedirectToAction("viewModule");
            }

            return View();


        }


    }
}