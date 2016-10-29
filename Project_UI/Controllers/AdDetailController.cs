using System.Data;
using System.Linq;
using System.Web.Mvc;
using Project_Entity;
using PagedList;

namespace Project_UI.Controllers
{
    public class AdDetailController : Controller
    {
        // GET: AdDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdDetail/Details/5
        public ActionResult Details(int ID)
        {
            return View();
        }
        public ActionResult LandDetail(int ID)
        {
            return View();
        }

        public ActionResult WorkDetail(int ID)
        {
            return View();
        }

        public ActionResult BuildDetail(int ID)
        {
            return View();
        }

    }
}
