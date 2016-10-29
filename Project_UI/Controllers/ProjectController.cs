using PagedList;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project

        public ActionResult Index(int? Id)
        {
            return View();
        }

        public ActionResult Detail(int ID)
        {
            return View();
        }
    }
}