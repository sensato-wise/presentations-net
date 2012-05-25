using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class SlideDisplayController : Controller
    {
        //
        // GET: /SlideDisplay/

        public ActionResult SlideDisplay()
        {
            return View();
        }

        public ActionResult Designer(PresentationModel model)
        {
            // схавываем презентацию, начинаем ее "создавать"
            return View();
        }


        public ActionResult Edit()
        {
            return View();
        }

    }
}
