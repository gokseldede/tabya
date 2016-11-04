using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using Project_BLL.Interfaces;
using Project_BLL.Implementation;
using Project_DAL;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class KimdenController : BaseController
    {

        private readonly IStandartService<Kimden> _kimdenService;

        public KimdenController()
        {
            _kimdenService = new StandartService<Kimden>(new EfRepositoryForEntityBase<Kimden>());
        }

        public KimdenController(IStandartService<Kimden> kimdenService)
        {
            _kimdenService = kimdenService;
        }

        // GET: Admin/Kimden
        public ActionResult Index()
        {
            List<Kimden> _kimden = _kimdenService.GetAll().ToList();
            return View(_kimden);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kimden _kimden)
        {
            try
            {
                _kimdenService.Create(_kimden);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            Kimden _kimden = _kimdenService.GetById(ID);
            return View(_kimden);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kimden _kimden)
        {
            try
            {
                _kimdenService.Edit(_kimden);
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
                _kimdenService.DeleteById(ID);
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
                _kimdenService.ChangeStatus(ID);
                var status = _kimdenService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}