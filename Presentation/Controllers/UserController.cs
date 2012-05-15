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

        public ActionResult Details(string Name, string ViewType )
        {
            var user = Membership.GetUser(Name);
            if (User.IsInRole("Admin") || User.Identity.Name == user.UserName)
            {
                var userModel = db.Users.Find(user.ProviderUserKey);
                var userDetailsModel = db.UserDetails.Find(userModel.UserId);
                if (userDetailsModel != null)
                {
                    var model = new UserEditModel();
                    model.UserName = Name;
                    model.ViewType = ViewType;
                    model.UserDetails = userDetailsModel;                    
                    return View(model);
                }
            }
            return RedirectToAction("../Home/Index");
        }
        
        // GET: /User/Edit/5
        [Authorize]
        public ActionResult Edit(string Name, string ViewType )
        {            
            var user = Membership.GetUser(Name);                      
            if ( User.IsInRole("Admin") || User.Identity.Name == user.UserName )
            {
                var userModel = db.Users.Find(user.ProviderUserKey);
                var userDetailsModel = db.UserDetails.Find(userModel.UserId); 
                if (userDetailsModel != null)
                {
                    ViewBag.Message = Name;                                        
                    var model = new UserEditModel();
                    model.ViewType = ViewType;
                    model.UserName = Name;
                    model.UserDetails = userDetailsModel;
                    return View(model);
                }
            }
            return RedirectToAction("../Home/Index");           
        }
        
        // POST: /User/Edit/5 
        [HttpPost]
        public ActionResult Edit(UserEditModel model)
        {                            
           if (User.IsInRole("Admin") || db.Users.Find(model.UserDetails.UserId).Name == User.Identity.Name )
            {               
                if (ModelState.IsValid)
                {                    
                    db.Entry(model.UserDetails).State = EntityState.Modified;
                    db.SaveChanges();
                    if (model.ViewType == "All")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        RouteValueDictionary routeValues = new RouteValueDictionary();
                        routeValues.Add("Name", model.UserName);
                        routeValues.Add("ViewType", model.ViewType);
                        return RedirectToAction("../User/Details",routeValues);
                    }
                }
                return View(model);
            }
           return RedirectToAction("../Home/Index");       
        }
        
        [Authorize]
        public ActionResult ResetPassword(string Name, string ViewType)
        {
            var user = Membership.GetUser(Name);
            if (User.IsInRole("Admin") || User.Identity.Name == user.UserName)
            {
                var model = new UserEditModel();
                model.UserName = Name;
                model.ViewType = ViewType;
                return View(model);
            }
            return RedirectToAction("../Home/Index");            
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ResetPassword(UserEditModel model)
        {
            if (ModelState.IsValid)
                {                            
                     MembershipUser currentUser = Membership.GetUser(model.UserName, true /* userIsOnline */);
                     string NewPass = currentUser.ResetPassword();
                     RouteValueDictionary routeValues = new RouteValueDictionary();
                     routeValues.Add("NewPassword", NewPass);
                     routeValues.Add("ViewType", model.ViewType);
                     routeValues.Add("UserName", model.UserName);
                     return RedirectToAction("ResetPasswordSuccess", routeValues);        
                }
            return View();
        }

        public ActionResult ResetPasswordSuccess(string NewPassword, string ViewType,string UserName)
        {
            ViewData["NewPassword"] = NewPassword;
            ViewData["ViewType"] = ViewType;
            ViewData["UserName"] = UserName;
            return View();            
        }
        
        // GET: /User/Delete/5

        public ActionResult Delete(string Name, string ViewType)
        {
            //User user = db.Users.Find(id);
            return View();            
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Name)
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