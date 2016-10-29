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
    public class IlController : BaseController
    {
        // GET: Admin/Il
        public ActionResult Index()
        {
            List<Il> _iller = Database.Iller.Where(x => x.IsDelete == false).ToList();
            return View(_iller);
        }

        // GET: Admin/Iller/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Iller/Create
        [HttpPost]

        public ActionResult Create(Il iller)
        {

            iller.IsDelete = false;
            iller.CreatedDate = DateTime.Now;
            iller.UpdatedDate = DateTime.Now;
            iller.IsActive = true;

            db.Iller.Add(iller);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Iller/Edit/5
        public ActionResult Edit(int ID)
        {
            Il iller = Database.Iller.FirstOrDefault(x => x.ID == ID);
            return View(iller);
        }

        // POST: Admin/Iller/Edit/5

        [HttpPost]
        public ActionResult Edit(Il iller)
        {
            Il _iller = Database.Iller.FirstOrDefault(x => x.ID == iller.ID);
            _iller.Ad = iller.Ad;
            _iller.ID = iller.ID;
            _iller.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public JsonResult Delete(int ID)
        {
            Il _iller = Database.Iller.Find(ID);
            _iller.IsDelete = true;
            _iller.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Il _iller = Database.Iller.Find(ID);
            _iller.IsActive = !_iller.IsActive;
            Database.SaveChanges();
            return Json(_iller.IsActive);
        }
    }
}