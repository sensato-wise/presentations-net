using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentation.Models;
using Presentation.Model;

namespace Presentation.Controllers
{ 
    public class PresentationController : Controller
    {
        private UserContext db = new UserContext();

        //
        // GET: /Presentation/

        public ViewResult Index()
        {
            return View(db.Presentation.ToList());
        }

        //
        // GET: /Presentation/Details/5

        public ViewResult Details(int id)
        {
            PresentationModel presentationmodel = db.Presentation.Find(id);
            return View(presentationmodel);
        }

        //
        // GET: /Presentation/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Presentation/Create

        [HttpPost]
        public ActionResult Create(PresentationModel presentationmodel)
        {
            if (ModelState.IsValid)
            {
                
                db.Presentation.Add(presentationmodel);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(presentationmodel);
        }
        
        //
        // GET: /Presentation/Edit/5
 
        public ActionResult Edit(int id)
        {
            PresentationModel presentationmodel = db.Presentation.Find(id);
            return View(presentationmodel);
        }

        //
        // POST: /Presentation/Edit/5

        [HttpPost]
        public ActionResult Edit(PresentationModel presentationmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presentationmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presentationmodel);
        }

        //
        // GET: /Presentation/Delete/5
 
        public ActionResult Delete(int id)
        {
            PresentationModel presentationmodel = db.Presentation.Find(id);
            return View(presentationmodel);
        }

        //
        // POST: /Presentation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PresentationModel presentationmodel = db.Presentation.Find(id);
            db.Presentation.Remove(presentationmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}