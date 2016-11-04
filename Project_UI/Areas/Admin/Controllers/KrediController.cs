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
    public class KrediController : BaseController
    {
        private readonly IStandartService<Kredi> _krediService;

        public KrediController()
        {
            _krediService = new StandartService<Kredi>(new EfRepositoryForEntityBase<Kredi>());
        }

        public KrediController(IStandartService<Kredi> krediService)
        {
            _krediService = krediService;
        }


        // GET: Admin/Kredi
        public ActionResult Index()
        {
            List<Kredi> _kredi = _krediService.GetAll().ToList();
            return View(_kredi);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kredi _kredi)
        {
            try
            {
                _krediService.Create(_kredi);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            Kredi _kredi = _krediService.GetById(ID);
            return View(_kredi);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kredi _kredi)
        {
            try
            {
                _krediService.Edit(_kredi);
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
                _krediService.DeleteById(ID);
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
                _krediService.ChangeStatus(ID);
                var status = _krediService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
