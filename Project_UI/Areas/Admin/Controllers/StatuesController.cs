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
    public class StatuesController : Controller
    {
        private readonly IStandartService<Status> _service;

        public StatuesController()
        {
            _service = new StandartService<Status>(new EfRepositoryForEntityBase<Status>());
        }

        public StatuesController(IStandartService<Status> service)
        {
            _service = service;
        }


        // GET: Admin/Statues
        public ActionResult Index()
        {
            List<Status> _status = _service.GetAll().ToList();
            return View(_status);
        }

        // GET: Admin/Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Status/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Status status)
        {
            try
            {
                _service.Create(status);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Admin/Status/Edit/5
        public ActionResult Edit(int ID)
        {
            Status status = _service.GetById(ID);
            return View(status);
        }

        // POST: Admin/Status/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Status status)
        {
            try
            {
                _service.Edit(status);
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