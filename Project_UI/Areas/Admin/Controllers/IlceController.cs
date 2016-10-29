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
    public class IlceController : BaseController
    {
        // GET: Admin/Ilce
        public ActionResult Index()
        {
            List<Ilce> _ılceler = Database.Ilceler.Where(x => x.IsDelete == false).ToList();
            return View(_ılceler);
        }

        // GET: Admin/Provinces/Create
        public ActionResult Create()
        {
            GetIl();
            return View();
        }


        // POST: Admin/Provinces/Create
        [HttpPost]

        public ActionResult Create(Ilce ilceler)
        {
            GetIl();
            ilceler.IsDelete = false;
            ilceler.CreatedDate = DateTime.Now;
            ilceler.UpdatedDate = DateTime.Now;
            ilceler.IsActive = true;

            db.Ilceler.Add(ilceler);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Provinces/Edit/5
        public ActionResult Edit(int ID)
        {
            GetIl(ID);
            Ilce ilce = Database.Ilceler.FirstOrDefault(x => x.ID == ID);
            return View(ilce);
        }

        // POST: Admin/Provinces/Edit/5

        [HttpPost]
        public ActionResult Edit(Ilce ilce)
        {
            Ilce _ilce = Database.Ilceler.FirstOrDefault(x => x.ID == ilce.ID);
            _ilce.Ad = ilce.Ad;
            _ilce.ID = ilce.ID;
            _ilce.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public JsonResult Delete(int ID)
        {
            Ilce _ilce = Database.Ilceler.Find(ID);
            _ilce.IsDelete = true;
            _ilce.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Ilce _ilce = Database.Ilceler.Find(ID);
            _ilce.IsActive = !_ilce.IsActive;
            Database.SaveChanges();
            return Json(_ilce.IsActive);
        }
    }
}