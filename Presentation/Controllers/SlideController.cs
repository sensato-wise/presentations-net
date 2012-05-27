using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentation.DAL;
using Presentation.Models;
using System.Collections;

namespace Presentation.Controllers
{
    public class SlideController : Controller
    {
        public ActionResult Image()
        {
            return View();
        }
    }
}
