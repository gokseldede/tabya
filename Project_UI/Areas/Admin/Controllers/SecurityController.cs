using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_DAL;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class SecurityController : BaseController
    {

        private readonly IStandartService<Securitys> _service;

        public SecurityController()
        {
            _service = new StandartService<Securitys>(new EfRepositoryForEntityBase<Securitys>());
        }

        public SecurityController(IStandartService<Securitys> service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            List<Securitys> _security = _service.GetAll().ToList();
            return View(_security);
        }

        // GET: Admin/Security/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Security/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Securitys security)
        {
            try
            {
                _service.Create(security);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Admin/Security/Edit/5
        public ActionResult Edit(int ID)
        {
            Securitys security = _service.GetById(ID);
            return View(security);
        }

        // POST: Admin/Security/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Securitys security)
        {
            try
            {
                _service.Edit(security);
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