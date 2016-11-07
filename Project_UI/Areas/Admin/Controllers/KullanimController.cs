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
    public class KullanimController : BaseController
    {
        private readonly IStandartService<Kullanim> _kullanimService;

        public KullanimController()
        {
            _kullanimService = new StandartService<Kullanim>(new EfRepositoryForEntityBase<Kullanim>());
        }

        public KullanimController(IStandartService<Kullanim> kullanimService)
        {
            _kullanimService = kullanimService;
        }

        // GET: Admin/Kullanım
        public ActionResult Index()
        {
            List<Kullanim> _kullanim = _kullanimService.GetAll().ToList();
            return View(_kullanim);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanim kullanim)
        {
            try
            {
                _kullanimService.Create(kullanim);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            Kullanim kullanim = _kullanimService.GetById(id);
            return View(kullanim);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kullanim kullanim)
        {
            try
            {
                _kullanimService.Edit(kullanim);
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
                _kullanimService.DeleteById(id);
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
                _kullanimService.ChangeStatus(id);
                var status = _kullanimService.GetById(id);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
