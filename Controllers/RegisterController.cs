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
    public class RegisterController : Controller
    {

        // GET: User
        [HandleError]
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
    }
}
    