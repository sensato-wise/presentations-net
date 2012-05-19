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


        public PresentationController()
        {
            this.repository = new
                PresentationRepository(new UserContext());
            this.tagRepository = new TagRepository();
        }

        //
        // GET: /Presentation/

        public ViewResult Index()
        {
            if (Request.IsAuthenticated)
            {
                Guid userId = repository.GetUserGUID(User.Identity.Name);
                var presentations = repository.GetPresentations(userId);
                return View(presentations);
            }
            else
                return View(repository.GetAllPresentations());
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

        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
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
                presentation.UserId = repository.GetUserGUID(User.Identity.Name);
                if (ModelState.IsValid)
                {
                    repository.InsertPresentation(presentation);
                    repository.Save();
                }
            }
            return RedirectToAction("Index");
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
        public ActionResult Edit(PresentationModel presentation)
        {
            if (ModelState.IsValid)
            {
                repository.UpdatePresentation(presentation);
                repository.Save();
                return RedirectToAction("Index");
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

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}