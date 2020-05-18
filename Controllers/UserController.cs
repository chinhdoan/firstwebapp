using Evncpc.DBModel;
using Evncpc.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User = Evncpc.DBModel.User;

namespace Evncpc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register(int id = 0)
        {
            UserModel userModel = new UserModel();
            return View(userModel);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Register(UserModel userModel)
        {
            using (MyDBEntities dbmodel = new MyDBEntities())
            {
                if (dbmodel.Users.Any(x => x.UserID == userModel.UserID))
                {
                    ViewBag.DuplicateMessage = "Username already exist";
                    return View("Register", userModel);
                }
                User users = new User();
                users.CreatedOn = DateTime.Now;
                users.Email = userModel.Email;
                users.UserName = userModel.UserName;
                users.FirstName = userModel.FirstName;
                users.LastName = userModel.LastName;
                users.Password = userModel.Password;
                dbmodel.Users.Add(users);
                dbmodel.SaveChanges();
                ModelState.Clear();
                ViewBag.SuccessMessage = "Registion successfull";
                return View("Register");
            }
           
        }

        [HttpPost]
        public ActionResult Login(LoginModel objloginModel)
        {
            using (MyDBEntities dbmodel = new MyDBEntities())
            {
                var check = dbmodel.Users.Where(m => m.UserName == objloginModel.UserName && m.Password == objloginModel.Password).FirstOrDefault();
                if (check == null)
                {
                    ViewBag.SuccessMessage = "Login failed";
                    ModelState.AddModelError("Error", "username and pass does not matching");
                    return View();
                }
                else
                {
                    Session["username"] = check.UserName;
                    ViewBag.SuccessMessage = "Login successfull";
                    return RedirectToAction("Index", "Home");
                }    
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "home");
        }
    }
}
    