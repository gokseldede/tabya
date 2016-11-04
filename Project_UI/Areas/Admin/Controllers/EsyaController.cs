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
    public class EsyaController : BaseController
    {
        private readonly IStandartService<Esya> _esyaService;

        public EsyaController()
        {
            _esyaService = new StandartService<Esya>(new EfRepositoryForEntityBase<Esya>());
        }

        public EsyaController(IStandartService<Esya> emlakTipService)
        {
            _esyaService = emlakTipService;
        }

        public ActionResult Index()
        {
            List<Esya> _esya = _esyaService.GetAll().ToList();
            return View(_esya);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Esya _esya)
        {
            try
            {
                _esyaService.Create(_esya);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            Esya _esya = _esyaService.GetById(ID);
            return View(_esya);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Esya _esya)
        {
            try
            {
                _esyaService.Edit(_esya);
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
                _esyaService.DeleteById(ID);
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
                _esyaService.ChangeStatus(ID);
                var status = _esyaService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
