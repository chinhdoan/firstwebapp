using Evncpc.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Evncpc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register(int id = 0)
        {
            user userModel = new user();
            return View(userModel);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Register(user userModel)
        {
            using (DbModels dbmodel = new DbModels())
            {
                if (dbmodel.users.Any(x => x.username == userModel.username))
                {
                    ViewBag.DuplicateMessage = "Username already exist";
                    return View("Register", userModel);
                }
                dbmodel.users.Add(userModel);
                dbmodel.SaveChanges();
                ModelState.Clear();
                ViewBag.SuccessMessage = "Registion successfull";
                return View("Register");
            }
           
        }

        [HttpPost]
        public ActionResult Login(user objloginModel)
        {
            using (DbModels dbmodel = new DbModels())
            {
                if (ModelState.IsValid)
                {
                    var check = dbmodel.users.Where(m => m.username == objloginModel.username && m.pass == objloginModel.pass).FirstOrDefault();
                    if ( check != null)
                    {
                        ViewBag.SuccessMessage = "Login failed";
                        ModelState.AddModelError("Error", "username and pass does not matching");
                        return View();
                    }
                    else
                    {
                        ViewBag.SuccessMessage = "Login successfull";
                        RedirectToAction("Index", "Home", "Home");
                    }

                }
            }
            return View();
        }
    }
}
    