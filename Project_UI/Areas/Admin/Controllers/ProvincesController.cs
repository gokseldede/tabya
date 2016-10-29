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
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class ProvincesController : BaseController
    {
       //Dış özellikler

        // GET: Admin/Provinces
        public ActionResult Index()
        {
            List<Province> _province = Database.Provinces.Where(x => x.IsDelete == false).ToList();
            return View(_province);
        }
        
        // GET: Admin/Provinces/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Admin/Provinces/Create
        [HttpPost]
        
        public ActionResult Create(Province province)
        {

            province.IsDelete = false;
            province.CreatedDate = DateTime.Now;
            province.UpdatedDate = DateTime.Now;
            province.IsActive = true;

            db.Provinces.Add(province);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: Admin/Provinces/Edit/5
        public ActionResult Edit(int ID)
        {
            Province province = Database.Provinces.FirstOrDefault(x => x.ID == ID);
            return View(province);
        }

        // POST: Admin/Provinces/Edit/5
       
        [HttpPost]
        public ActionResult Edit(Province province)
        {
            Province _province = Database.Provinces.FirstOrDefault(x => x.ID == province.ID);
            _province.Name = province.Name;
            _province.ID = province.ID;
            _province.UpdatedDate = DateTime.Now;
            db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        public JsonResult Delete(int ID)
        {
            Province _province = Database.Provinces.Find(ID);
            _province.IsDelete = true;
            _province.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Province _province = Database.Provinces.Find(ID);
            _province.IsActive = !_province.IsActive;
            Database.SaveChanges();
            return Json(_province.IsActive);
        }

    }
}
