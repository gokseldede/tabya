using PagedList;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Controllers
{
    public class ExpertController : Controller
    {
        // GET: Expert
        public ActionResult Index(int? Id)
        {
            return View();
        }
    }
}