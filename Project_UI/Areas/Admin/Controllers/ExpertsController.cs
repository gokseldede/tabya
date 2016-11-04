using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_DAL;
using Project_Entity;
using System.IO;
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
            List<Expert> _experts = _expertService.GetAll().ToList();
            return View(_experts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expert _expert, HttpPostedFileBase document)
        {
            try
            {
                var imagePath = Functions.UploadImage(document);
                _expert.ImagePath = imagePath;
                _expertService.Create(_expert);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {

            Expert _expert = _expertService.GetById(ID);
            return View(_expert);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expert _expert, HttpPostedFileBase document)
        {
            try
            {
                if (document != null)
                {
                    var imagePath = Functions.UploadImage(document);
                    _expert.ImagePath = imagePath;
                }
                _expertService.Edit(_expert);
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
                _expertService.DeleteById(ID);
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
                _expertService.ChangeStatus(ID);
                var status = _expertService.GetById(ID);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
