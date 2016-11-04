using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_DAL;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class SiteController : BaseController
    {
        private readonly IStandartService<Site> _siteService;

        public SiteController()
        {
            _siteService = new StandartService<Site>(new EfRepositoryForEntityBase<Site>());
        }

        public SiteController(IStandartService<Site> siteService)
        {
            _siteService = siteService;
        }

        // GET: Admin/Site
        public ActionResult Index()
        {
            List<Site> _site = _siteService.GetAll().ToList();
            return View(_site);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Site _site)
        {
            try
            {
                _siteService.Create(_site);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            Site _site = _siteService.GetById(ID);
            return View(_site);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Site _site)
        {
            try
            {
                _siteService.Edit(_site);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }


        public JsonResult Delete(int ID)
        {
            try
            {
                _siteService.DeleteById(ID);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public JsonResult Status(int ID)
        {
            try
            {
                _siteService.ChangeStatus(ID);
                var status = _siteService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}