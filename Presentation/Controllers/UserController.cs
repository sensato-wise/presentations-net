using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentation.Models;
using Presentation.Model;
using System.Web.Security;
using System.Collections;

namespace Presentation.Controllers
{ 
    public class UserController : Controller
    {
        private UserContext db = new UserContext();
        private MembershipUser EditedUser;
        //
        // GET: /User/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {            
            System.Web.Security.MembershipUserCollection mc = Membership.GetAllUsers();            
           // return View(db.Users.ToList());            
            /*mc[0].CreationDate
            mc[0].Email
            mc[0].IsOnline
            mc[0].UserName
            mc[0].LastActivityDate
            mc[0].
            mc[0].ResetPassword*/
            return View(mc);            
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(Guid id)
        {
            User user = db.Users.Find(id);
            
            UserDetails a = db.UserDetails.Find(id);
            return View(user);
        }
                
        //
        // GET: /User/Edit/5
        //
        // POST: /User/Edit/5        
        public ActionResult Edit(string name)
        {
            var user = Membership.GetUser(name);
            if ( User.IsInRole("Admin") || User.Identity.Name == user.UserName )
            {
                EditedUser = user;
                return View(user);
            }
            return RedirectToAction("Index");
            /*if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);*/
        }
        [HttpPost]
        public ActionResult Edit(MembershipUser user)
        {
            if (ModelState.IsValid)
            {
                if (EditedUser != null)
                {
                    Membership.UpdateUser(EditedUser);                    
                }
            }
          //  if (User.IsInRole("Admin") || User.Identity.Name == user.UserName)
            {
              //  return View(user);
            }
            return RedirectToAction("Index");
            /*if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);*/
        }
        //
        // GET: /User/Delete/5

        public ActionResult Delete(MembershipUser user)
        {
            //User user = db.Users.Find(id);
            return View(user);
            
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {            
            //User user = db.Users.Find(id);
            //Membership.DeleteUser(user.Name, true);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            //base.Dispose(disposing);
        }
    }
}