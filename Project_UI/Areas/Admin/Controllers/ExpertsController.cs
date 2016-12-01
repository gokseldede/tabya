using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_DAL;
using Project_Entity;
using Project_UI.Areas.Admin.Models;
using Project_UI.Areas.Admin.FilterAttributes;
using Project_BLL.Interfaces;
using Project_BLL.Implementation;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class ExpertsController : BaseController
    {
        private readonly IExpertService _expertService;
        public ExpertsController()
        {
            _expertService = new ExpertService(new EfRepositoryForEntityBase<Expert>());
        }
        public ExpertsController(IExpertService expertService)
        {
            _expertService = expertService;
        }
        public ActionResult Index()
        {
            List<Expert> experts = _expertService.GetAll().ToList();
            return View(experts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expert expert, HttpPostedFileBase document)
        {
            try
            {
                var imagePath = Functions.UploadImage(document);
                expert.ImagePath = imagePath;
                _expertService.Create(expert);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {

            Expert expert = _expertService.GetById(id);
            return View(expert);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expert expert, HttpPostedFileBase document)
        {
            try
            {
                if (document != null)
                {
                    var imagePath = Functions.UploadImage(document);
                    expert.ImagePath = imagePath;
                }

                _expertService.Edit(expert);
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
                _expertService.DeleteById(id);
                return Json(new { result = true });
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }
        }

        public JsonResult Status(int id)
        {
            try
            {
                _expertService.ChangeStatus(id);
                var status = _expertService.GetById(id);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
