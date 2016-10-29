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
    public class IsinmaController : BaseController
    {

        private readonly IStandartService<Isinma> _isinmaService;

        public IsinmaController()
        {
            _isinmaService = new StandartService<Isinma>(new EfRepository<Isinma>());
        }

        public IsinmaController(IStandartService<Isinma> isinmaService)
        {
            _isinmaService = isinmaService;
        }


        // GET: Admin/Isınma
        public ActionResult Index()
        {
            List<Isinma> _ısınma = _isinmaService.GetAll().ToList();
            return View(_ısınma);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Isinma _isinma)
        {
            try
            {
                _isinmaService.Create(_isinma);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            Isinma _ısınma = _isinmaService.GetById(ID);
            return View(_ısınma);

        }

        [HttpPost]
        public ActionResult Edit(Isinma _isinma)
        {
            try
            {
                _isinmaService.edit(_isinma);
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
                _isinmaService.DeleteById(ID);
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
                _isinmaService.ChangeStatus(ID);
                var status = _isinmaService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
