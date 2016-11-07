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
            List<Esya> esya = _esyaService.GetAll().ToList();
            return View(esya);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Esya esya)
        {
            try
            {
                _esyaService.Create(esya);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            Esya esya = _esyaService.GetById(id);
            return View(esya);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Esya esya)
        {
            try
            {
                _esyaService.Edit(esya);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }


        public JsonResult Delete(int id)
        {
            try
            {
                _esyaService.DeleteById(id);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public JsonResult Status(int id)
        {
            try
            {
                _esyaService.ChangeStatus(id);
                var status = _esyaService.GetById(id);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
