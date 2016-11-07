using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project_UI.Areas.Admin.Models;

namespace Project_UI.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel _model)
        {
            if (Database.AdminUsers.Any(x => x.Email == _model.EMail && x.Password == _model.Password))
            {
                FormsAuthentication.SetAuthCookie(_model.EMail, true);
                var currentUser = Database.AdminUsers.FirstOrDefault(x => x.Email == _model.EMail);
                string name = currentUser.Name + " " + currentUser.Surname + "" + currentUser.ImagePath;
                Session.Add("Login", name);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.error = "EMail veya parola hatalı";
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}