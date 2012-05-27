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
            Guid currentUser = new Guid();
            if (User.Identity.Name != "")
            {
                currentUser = currentUser = repository.GetUserGUID(User.Identity.Name);                                        
            } 
            foreach (var presentationModel in presentations)
            {
                presentationModel.UserName = repository.GetUserNameById(presentationModel.UserId);
                
                presentationModel.AverageRating = repository.GetAverageRating(presentationModel.PresentationId);
                presentationModel.IsRatedByOne = presentationModel.AverageRating != null;
                if (User.Identity.Name != "")
                {
                    presentationModel.IsRatedByUser = repository.IsRatedByUserId(presentationModel.PresentationId, currentUser);
                    presentationModel.UserRate = repository.GetUserRating(presentationModel.PresentationId, currentUser);
                } else
                {
                    presentationModel.IsRatedByUser = false;
                    presentationModel.UserRate = 0;
                }
            }
            return View(presentations);            
        }

        [HttpPost]
        public ActionResult Vote(string UserName, int PresentationId, string Rating)
        {
            var UserId = repository.GetUserGUID(UserName);
            repository.AddNewVote(UserId, PresentationId, Int32.Parse(Rating.Remove(0, 13)));
            repository.Save();
            return null;
        }
    }
}
