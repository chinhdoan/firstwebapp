using Evncpc.DBModel;
using Evncpc.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Evncpc.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        
        public ActionResult Register(int id = 0)
        {

            return View();
        }


        [HttpPost]

        public ActionResult Register(UserModel userModel)
        {
            using (webdbEntities dbmodel = new webdbEntities())
            {
                if (dbmodel.users.Any(x => x.user_name == userModel.user_name))
                {
                    ViewBag.Message = "UserName already exist";
                    return View("Register");
                }
                else if(dbmodel.users.Any(x => x.email == userModel.email))
                {
                    ViewBag.Message = "Email already exist";
                    return View("Register");
                }
                else
                {
                    user users = new user();
                    users.created_on = DateTime.Now;
                    users.email = userModel.email;
                    users.user_name = userModel.user_name;
                    users.first_name = userModel.first_name;
                    users.last_name = userModel.last_name;
                    users.password = userModel.password;
                    users.confirm_password = userModel.confirm_password;
                    dbmodel.users.Add(users);
                    dbmodel.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = "Register success! Now you can log-in";
                    return View("Register");
                }
            }  
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel objloginModel)
        {
            using (webdbEntities dbmodel = new webdbEntities())
            {
                var check = dbmodel.users.Where(m => m.user_name == objloginModel.user_name && m.password == objloginModel.password).FirstOrDefault();
                if (check == null)
                {
                    ViewBag.Message = "Login failed";
                    ModelState.AddModelError("Error", "username and pass does not matching");
                    return View();
                }
                else
                {
                    Session["username"] = check.user_name;
                    ViewBag.Message = "Login successfull";
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
    