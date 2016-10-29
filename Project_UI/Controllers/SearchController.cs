using PagedList;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();

        }

        //Kelime bazlı üst arama kısmı çalışır halde
        public ActionResult Query(string search)
        {
            return View();
        }
        public ActionResult QueryResult()
        {
            return View();
        }
    }
}