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
        private readonly IStandartService<Kullanım> _kullanimService;

        public KullanimController()
        {
            _kullanimService = new StandartService<Kullanım>(new EfRepository<Kullanım>());
        }

        public KullanimController(IStandartService<Kullanım> kullanimService)
        {
            _kullanimService = kullanimService;
        }

        // GET: Admin/Kullanım
        public ActionResult Index()
        {
            List<Kullanım> _kullanim = _kullanimService.GetAll().ToList();
            return View(_kullanim);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanım _kullanim)
        {
            try
            {
                _kullanimService.Create(_kullanim);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            Kullanım _kullanim = _kullanimService.GetById(ID);
            return View(_kullanim);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kullanım _kullanim)
        {
            try
            {
                _kullanimService.edit(_kullanim);
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
                _kullanimService.DeleteById(ID);
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
                _kullanimService.ChangeStatus(ID);
                var status = _kullanimService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
