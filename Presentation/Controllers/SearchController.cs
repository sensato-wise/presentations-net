using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentation.DAL;
using Presentation.Model;

namespace Presentation.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        
        public ActionResult Index()
        {
            var repository = new PresentationRepository(new UserContext());
            return View(repository.GetAllPresentations());            
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            ViewBag.Message = searchString;

            // this code must be changed
            var repository = new PresentationRepository(new UserContext());
            return View(repository.GetAllPresentations());
        }
    }
}
