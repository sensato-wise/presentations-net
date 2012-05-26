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
        private IPresentationRepository repository;

        public SearchController()
        {
            repository = new PresentationRepository();
        }
        
        public ActionResult Index()
        {            
            var presentations = repository.GetAllPresentations();
            foreach (var presentationModel in presentations)
            {
                presentationModel.UserName = repository.GetUserNameById(presentationModel.UserId);
            }
            return View(presentations);            
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            ViewBag.Message = searchString;
            // this code must be changed
            //var repository = new PresentationRepository();
            //return View(repository.GetAllPresentations());
            var presentations = repository.GetPresentations(searchString);
            foreach (var presentationModel in presentations)
            {
                presentationModel.UserName = repository.GetUserNameById(presentationModel.UserId);
            }
            return View(presentations);            
        }

        [HttpPost]
        public ActionResult Vote(Guid UserId, int PresentationId, string Rating)
        {
            repository.AddNewVote(UserId, PresentationId, Int32.Parse(Rating.Remove(0, 13)));              
            return null;
        }
    }
}
