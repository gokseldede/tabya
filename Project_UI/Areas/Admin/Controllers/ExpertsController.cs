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

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class ExpertsController : BaseController
    {

        public ActionResult Index()
        {
            List<Expert> _experts = Database.Experts.Where(x => x.IsDelete == false).ToList();
            return View(_experts);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Create(Expert _expert, HttpPostedFileBase document)
        {
          
            

            _expert.IsDelete = false;
            _expert.CreatedDate = DateTime.Now;
            _expert.UpdatedDate = DateTime.Now;
            _expert.IsActive = true;

            var imagePath = Functions.UploadImage(document);
            _expert.ImagePath = imagePath;

            Database.Experts.Add(_expert);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID, HttpPostedFileBase image)
        {
           
            Expert _expert = Database.Experts.FirstOrDefault(x => x.ID == ID);
            TempData["ImagePath"] = _expert.ImagePath;
            return View(_expert);

        }
        [HttpPost]
        public ActionResult Edit(Expert _expert, HttpPostedFileBase document)
        {
           
            Expert expert = Database.Experts.FirstOrDefault(x => x.ID == _expert.ID);

            if (document != null)
            {
                var imagePath = Functions.UploadImage(document);
                expert.ImagePath = imagePath;
            }
            else
            {
                expert.ImagePath = TempData["ImagePath"].ToString();
            }

            expert.Name = _expert.Name;
            expert.PhoneNumber = _expert.PhoneNumber;
            expert.Title = _expert.Title;
            expert.ID = _expert.ID;
            expert.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");


        }


        public JsonResult Delete(int ID)
        {
            Expert _expert = Database.Experts.Find(ID);
            _expert.IsDelete = true;
            _expert.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Expert _expert = Database.Experts.Find(ID);
            _expert.IsActive = !_expert.IsActive;
            Database.SaveChanges();
            return Json(_expert.IsActive);
        }
    }
}
