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


    }
}