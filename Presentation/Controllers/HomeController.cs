using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentation.Models;
using Presentation.Model;
using System.Web.Security;


namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Presentations-net!";
            // создаются один раз ( закоменчено, т.к. роли уже созданы. декларативно хз как сделать
            // Roles.CreateRole("User");
            // Roles.CreateRole("Admin");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
