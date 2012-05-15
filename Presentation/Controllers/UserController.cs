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
using System.Web.Routing;

namespace Presentation.Controllers
{ 
    public class UserController : Controller
    {
        private UserContext db = new UserContext();        
        
        // GET: /User/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {            
            var users = Membership.GetAllUsers();
            return View(users);         
        }
        
        // GET: /User/Details/5

        public ActionResult Details(string name)
        {
            var user = Membership.GetUser(name);
            if (User.IsInRole("Admin") || User.Identity.Name == user.UserName)
            {
                var userModel = db.Users.Find(user.ProviderUserKey);
                var userDetailsModel = db.UserDetails.Find(userModel.UserId);
                if (userDetailsModel != null)
                {
                    ViewBag.Message = name;
                    return View(userDetailsModel);
                }
            }
            return RedirectToAction("../Home/Index");
        }
        
        // GET: /User/Edit/5
        [Authorize]
        public ActionResult Edit(string name)
        {            
            var user = Membership.GetUser(name);                      
            if ( User.IsInRole("Admin") || User.Identity.Name == user.UserName )
            {
                var userModel = db.Users.Find(user.ProviderUserKey);
                var userDetailsModel = db.UserDetails.Find(userModel.UserId);
                if (userDetailsModel != null)
                {
                    ViewBag.Message = name;                                        
                    return View(userDetailsModel);
                }
            }
            return RedirectToAction("../Home/Index");           
        }
        
        // POST: /User/Edit/5 
        [HttpPost]
        public ActionResult Edit(UserDetailsModel user)
        {                                  
           if (User.IsInRole("Admin") || db.Users.Find(user.UserId).Name == User.Identity.Name )
            {               
                if (ModelState.IsValid)
                {                    
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
           return RedirectToAction("../Home/Index");       
        }
        
        [Authorize]
        public ActionResult ResetPassword(string name)
        {
            var user = Membership.GetUser(name);
            if (User.IsInRole("Admin") || User.Identity.Name == user.UserName)
            {                                        
                var model = new UserNameModel();
                model.UserName = name;
                return View(model);
            }
            return RedirectToAction("Index");            
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ResetPassword(UserNameModel model)
        {
            if (ModelState.IsValid)
                {                   
                     MembershipUser currentUser = Membership.GetUser(model.UserName, true /* userIsOnline */);
                     string NewPass = currentUser.ResetPassword();
                     RouteValueDictionary routeValues = new RouteValueDictionary();
                     routeValues.Add("NewPassword", NewPass);
                     return RedirectToAction("ResetPasswordSuccess", routeValues);        
                }
            return View();
        }

        public ActionResult ResetPasswordSuccess(string NewPassword)
        {
            ViewData["NewPassword"] = NewPassword;
            return View();
        }
        
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
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}