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
    public class PropertiesController : BaseController
    {
        private readonly IStandartService<Properties> _service;

        public PropertiesController()
        {
            _service = new StandartService<Properties>(new EfRepositoryForEntityBase<Properties>());
        }

        public PropertiesController(IStandartService<Properties> service)
        {
            _service = service;
        }

        // GET: Admin/Properties
        public ActionResult Index()
        {
            List<Properties> _properties = _service.GetAll().ToList();
            return View(_properties);
        }

        // GET: Admin/Provinces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Provinces/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Properties properties)
        {
            try
            {
                _service.Create(properties);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Admin/Provinces/Edit/5
        public ActionResult Edit(int ID)
        {
            Properties properties = _service.GetById(ID);
            return View(properties);
        }

        // POST: Admin/Provinces/Edit/5

        [HttpPost]
        public ActionResult Edit(Properties properties)
        {
            try
            {
                _service.Edit(properties);
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