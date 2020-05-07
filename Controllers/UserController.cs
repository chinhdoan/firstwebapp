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
        public ActionResult AddOrEdit(int id=0)
        {
            user userModel = new user();
            return View(userModel);
        }

        [HttpPost]
        
        public ActionResult AddOrEdit(user userModel)
        {
            using (DbModels dbmodel = new DbModels())
            {
                dbmodel.users.Add(userModel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registion successfull";
            return View("AddOrEdit", new user());
        }
    }
}