using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCReleaseManagementProject.Models;

namespace MVCReleaseManagementProject.Controllers
{
    
    public class LogInController : Controller
    {
        List<string> roles = new List<string>() {"teamlead","manager","developer","tester"};

        releaseProjectEntities dbContext = new releaseProjectEntities();
        // GET: LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogIn loginDetails)
        {
            LogIn result = dbContext.LogIns.FirstOrDefault(log=>log.userId.Equals(loginDetails.userId)&&(log.password.Equals(loginDetails.password)));
            if(result != null)
            {
                switch (result.role)
                {
                    case "manager":  return RedirectToAction("index","Manager");
                    case "teamlead": return RedirectToAction("index","TeamLead");
                    case "developer":
                        TempData["developer"] = result.userId;
                        return RedirectToAction("index","developer");
                    case "tester":
                        TempData["testerId"] = result.userId;
                        return RedirectToAction("index","Tester");
                }
            }
            return View();
        }
    }
}