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
    public class PropertiesController : BaseController
    {
        // GET: Admin/Properties
        public ActionResult Index()
        {
            List<Properties> _properties = Database.Propertiesis.Where(x => x.IsDelete == false).ToList();
            return View(_properties);
        }

        // GET: Admin/Provinces/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Provinces/Create
        [HttpPost]

        public ActionResult Create(Properties properties)
        {

           properties.IsDelete = false;
           properties.CreatedDate = DateTime.Now;
           properties.UpdatedDate = DateTime.Now;
            properties.IsActive = true;

            db.Propertiesis.Add(properties);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Provinces/Edit/5
        public ActionResult Edit(int ID)
        {
            Properties properties = Database.Propertiesis.FirstOrDefault(x => x.ID == ID);
            return View(properties);
        }

        // POST: Admin/Provinces/Edit/5

        [HttpPost]
        public ActionResult Edit(Properties properties)
        {
            Properties _properties = Database.Propertiesis.FirstOrDefault(x => x.ID == properties.ID);
            _properties.Name = properties.Name;
            _properties.ID = properties.ID;
            _properties.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public JsonResult Delete(int ID)
        {
            Properties _properties = Database.Propertiesis.Find(ID);
            _properties.IsDelete = true;
            _properties.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Properties _properties = Database.Propertiesis.Find(ID);
            _properties.IsActive = !_properties.IsActive;
            Database.SaveChanges();
            return Json(_properties.IsActive);
        }
    }
}