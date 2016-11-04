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
    public class ImarController : BaseController
    {
        private readonly IStandartService<Imar> _imarService;

        public ImarController()
        {
            _imarService = new StandartService<Imar>(new EfRepositoryForEntityBase<Imar>());
        }

        public ImarController(IStandartService<Imar> imarService)
        {
            _imarService = imarService;
        }

        public ActionResult Index()
        {
            List<Imar> _imar = _imarService.GetAll().ToList();
            return View(_imar);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Imar _imar)
        {
            try
            {
                _imarService.Create(_imar);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            Imar _imar = _imarService.GetById(ID);
            return View(_imar);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Imar _imar)
        {
            try
            {
                _imarService.Edit(_imar);
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
                _imarService.DeleteById(ID);
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
                _imarService.ChangeStatus(ID);
                var status = _imarService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}