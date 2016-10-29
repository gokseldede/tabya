using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_DAL;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class SocialPropertiesController : BaseController
    {
        private readonly IStandartService<SocialApps> _service;

        public SocialPropertiesController()
        {
            _service = new StandartService<SocialApps>(new EfRepository<SocialApps>());
        }

        public SocialPropertiesController(IStandartService<SocialApps> service)
        {
            _service = service;
        }

        // GET: Admin/SocialProperties
        public ActionResult Index()
        {
            List<SocialApps> _socialapps = _service.GetAll().ToList();
            return View(_socialapps);
        }

        // GET: Admin/Social/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Social/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SocialApps socialapps)
        {
            try
            {
                _service.Create(socialapps);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Admin/Social/Edit/5
        public ActionResult Edit(int ID)
        {
            SocialApps socialapps = _service.GetById(ID);
            return View(socialapps);
        }

        // POST: Admin/Social/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SocialApps socialapps)
        {
            try
            {
                _service.edit(socialapps);
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
                _service.DeleteById(ID);
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
                _service.ChangeStatus(ID);
                var status = _service.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}