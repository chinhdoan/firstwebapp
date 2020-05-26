using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evncpc.DBModel;
using Evncpc.Models;
namespace Evncpc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HandleError]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel objloginModel)
        {
            using (webdbEntities dbmodel = new webdbEntities())
            {
                var check = dbmodel.users.Where(m => m.user_name == objloginModel.UserName && m.password == objloginModel.Password).FirstOrDefault();
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