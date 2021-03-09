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
        public List<SelectListItem> listOfroles = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Developer", Value = "developer"},
            new SelectListItem() { Text = "Tester", Value = "tester"},
            new SelectListItem() { Text = "Team Lead", Value = "teamlead"},
            new SelectListItem() { Text = "Manager", Value = "manager"},
        };
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
                    case "manager":  return RedirectToAction("viewProject", "Manager");
                    case "teamlead": return RedirectToAction("viewModule", "TeamLead");
                    case "developer":
                        TempData["developer"] = result.userId;
                        return RedirectToAction("viewModule", "developer");
                    case "tester":
                        TempData["testerId"] = result.userId;
                        return RedirectToAction("viewModule", "Tester");
                }
            }
            return View();
        }

        public ActionResult registerEmployee()
        {
            ViewBag.roles = listOfroles;
            return View();
        }

        [HttpPost]
        public ActionResult registerEmployee(signupViewModel signup)
        {
            ViewBag.roles = listOfroles;
            Employee employee = new Employee();
            employee.Id = signup.Id;
            employee.Name = signup.Name;
            employee.Role = signup.role;
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            LogIn logIn = new LogIn();
            logIn.userId = signup.Id;
            logIn.password = signup.password;
            logIn.role = signup.role;
            dbContext.LogIns.Add(logIn);
            dbContext.SaveChanges();

            return View("LogIn");
        }
    }
}