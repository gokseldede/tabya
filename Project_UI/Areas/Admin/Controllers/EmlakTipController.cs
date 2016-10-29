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
            _emlakTipService = new StandartService<EmlakTip>(new EfRepository<EmlakTip>());
        }

        public EmlakTipController(IStandartService<EmlakTip> emlakTipService)
        {
            _emlakTipService = emlakTipService;
        }


        public ActionResult Index()
        {
            List<EmlakTip> _emlak = _emlakTipService.GetAll().ToList();
            return View(_emlak);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmlakTip _emlak)
        {
            try
            {
                _emlakTipService.Create(_emlak);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            EmlakTip _emlak = _emlakTipService.GetById(ID);
            return View(_emlak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmlakTip _emlak)
        {
            try
            {
                _emlakTipService.edit(_emlak);
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
                _emlakTipService.DeleteById(ID);
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
                _emlakTipService.ChangeStatus(ID);
                var status = _emlakTipService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
