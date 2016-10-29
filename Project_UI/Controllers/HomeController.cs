using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Entity;
using PagedList;

namespace Project_UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetirIlceler(int ilId)
        {
            return Json("");
        }

        [HttpPost]
        public JsonResult GetirSemtler(int ilceId)
        {
            return Json("");
        }
    }
}