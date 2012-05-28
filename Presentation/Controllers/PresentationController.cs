using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentation.Models;
using Presentation.Model;
using Presentation.DAL;

namespace Presentation.Controllers
{
    public class PresentationController : Controller
    {

        private IPresentationRepository repository;
        private ITagsRepository tagRepository;
        private ISlideRepository slideRepository;
        

        public PresentationController()
        {
            this.repository = new PresentationRepository();
            this.tagRepository = new TagRepository();
            this.slideRepository = new SlideRepository();
        }

        //
        // GET: /Presentation/

        public ViewResult Index()
        {
            if (Request.IsAuthenticated)
            {
                Guid userId = repository.GetUserGUID(User.Identity.Name);
                var presentations = repository.GetPresentations(userId);
                foreach (var presentationModel in presentations)
                {
                    presentationModel.UserName = repository.GetUserNameById(presentationModel.UserId);
                    presentationModel.AverageRating = repository.GetAverageRating(presentationModel.PresentationId);
                    presentationModel.IsRatedByOne = presentationModel.AverageRating != null;
                    presentationModel.IsRatedByUser = repository.IsRatedByUserId(presentationModel.PresentationId, userId);
                    presentationModel.UserRate = repository.GetUserRating(presentationModel.PresentationId, userId);
                }
                return View(presentations);
            }
            else
            {
                var presentations = repository.GetAllPresentations();
                foreach (var presentationModel in presentations )
                {
                    presentationModel.UserName = repository.GetUserNameById(presentationModel.UserId);
                }
                return View(presentations);            
            }
        }

        //
        // GET: /Presentation/Details/5

        public ViewResult Details(int id)
        {
            var presentation = repository.GetPresentation(id);
            return View(presentation);
        }

        //
        // GET: /Presentation/Create

        public ActionResult Create(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (!id.HasValue)
                {
                    var model = new PresentationModel();
                    model.UserId = repository.GetUserGUID(User.Identity.Name);
                    repository.InsertPresentation(model);
                    repository.Save();
                    return Redirect("CreateSlides?id=" + model.PresentationId);
                }
                else
                    return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



        //
        // POST: /Presentation/Create

        [HttpPost]
        public ActionResult Create(PresentationModel presentation)
        {
            if (Request.IsAuthenticated)
            {
                var existPresentation = CopyPresentation(presentation);
                if (ModelState.IsValid)
                {
                    repository.UpdatePresentation(existPresentation);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        private PresentationModel CopyPresentation(PresentationModel source)
        {
            int id = source.PresentationId;
            var presentation = repository.GetPresentation(id);
            presentation.Name = source.Name;
            presentation.Description = source.Description;
            presentation.Tags = source.Tags;
            return presentation;
        }
        //
        // GET: /Presentation/Edit/5

        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                var presentation = repository.GetPresentation(id);
                Guid userId = repository.GetUserGUID(User.Identity.Name);
                if (userId.Equals(presentation.UserId))
                    return View(presentation);
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Presentation/Edit/5

        [HttpPost]
        [Authorize()]
        public ActionResult Edit(PresentationModel presentation)
        {
            if (Request.IsAuthenticated)
            {
                presentation.UserId = repository.GetUserGUID(User.Identity.Name);
                if (ModelState.IsValid)
                {
                    repository.UpdatePresentation(presentation);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            return View(presentation);
        }
        //
        // GET: /Presentation/Delete/5

        public ActionResult Delete(int id)
        {
            if (Request.IsAuthenticated)
            {

                var presentation = repository.GetPresentation(id);
                Guid userId = repository.GetUserGUID(User.Identity.Name);
                if (userId.Equals(presentation.UserId))
                    return View(presentation);
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Presentation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeletePresentation(id);
            repository.Save();
            return RedirectToAction("Index");
        }


        public ActionResult Tags()
        {
            var tags = tagRepository.GetTags();
            return View(tags);
        }


        #region work with slides

        public ActionResult EditSlides(int id)
        {
            return View();
        }


        public ActionResult CreateSlides(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSlides()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(string[] images, int id)
        {
            for (int i = 1; i < images.Length; ++i)
            {
                var slide = slideRepository.GetSlide(id, i);
                if (slide == null)
                {
                    SlideModel newSlide = new SlideModel();
                    newSlide.Data = images[i];
                    newSlide.PresentationId = id;
                    newSlide.SlideNumber = i;
                    slideRepository.InsertSlide(newSlide);
                    slideRepository.Save();
                }
                else
                {
                    slide.Data = images[i];
                    slideRepository.UpdateSlide(slide);
                    slideRepository.Save();
                }
            }
            return null;
        }

        public ActionResult GetSlides(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }
            var slides = slideRepository.GetSlides(id.Value);
            string[] images = new string[slides.Count()];
            int i = 0;
            foreach (var slide in slides)
            {
                images[i] = slide.Data;
                ++i;
            }
            return Json(images, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SlideShow(int id)
        {
            var presentation = repository.GetPresentation(id);
            return View(presentation);
        }

        #endregion // work with slides





        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}