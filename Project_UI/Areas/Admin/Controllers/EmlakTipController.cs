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
    public class EmlakTipController : Controller
    {
        private readonly IStandartService<EmlakTip> _emlakTipService;
        
        public EmlakTipController()
        {
            _emlakTipService = new StandartService<EmlakTip>(new EfRepositoryForEntityBase<EmlakTip>());
        }

        public EmlakTipController(IStandartService<EmlakTip> emlakTipService)
        {
            _emlakTipService = emlakTipService;
        }


        public ActionResult Index()
        {
            List<EmlakTip> emlak = _emlakTipService.GetAll().ToList();
            return View(emlak);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmlakTip emlak)
        {
            try
            {
                _emlakTipService.Create(emlak);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            EmlakTip emlak = _emlakTipService.GetById(id);
            return View(emlak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmlakTip emlak)
        {
            try
            {
                _emlakTipService.Edit(emlak);
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
                _emlakTipService.DeleteById(id);
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
                _emlakTipService.ChangeStatus(id);
                var status = _emlakTipService.GetById(id);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
