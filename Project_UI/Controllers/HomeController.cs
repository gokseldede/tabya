using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Entity;
using PagedList;
using Project_BLL.Interfaces;
using Project_BLL.Implementation;

namespace Project_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebSiteService _service;

        public HomeController()
        {
            _service = new WebSiteService();
        }
        public HomeController(IWebSiteService service)
        {
            _service = service;
        }


        public ActionResult Index()
        {
            var vm = _service.GetMainPageData();
            return View(vm);
        }

        [HttpPost]
        public JsonResult GetirIlceler(string ilId)
        {
            int _ilId;
            if (int.TryParse(ilId, out _ilId) == false)
            {
                return Json("İnteger değer göndermelisin dostum:)");
            }

            var result = _service.GetCounties(_ilId);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetirSemtler(int ilceId)
        {
            return Json("");
        }
    }
}