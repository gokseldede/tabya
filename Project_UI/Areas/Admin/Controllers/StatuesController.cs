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
    public class StatuesController : BaseController
    {
        // GET: Admin/Statues
        public ActionResult Index()
        {
            List<Status> _status = Database.Statues.Where(x => x.IsDelete == false).ToList();
            return View(_status);
        }

        // GET: Admin/Status/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Status/Create
        [HttpPost]

        public ActionResult Create(Status status)
        {

            status.IsDelete = false;
            status.CreatedDate = DateTime.Now;
            status.UpdatedDate = DateTime.Now;
            status.IsActive = true;

            db.Statues.Add(status);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Status/Edit/5
        public ActionResult Edit(int ID)
        {
            Status status = Database.Statues.FirstOrDefault(x => x.ID == ID);
            return View(status);
        }

        // POST: Admin/Status/Edit/5

        [HttpPost]
        public ActionResult Edit(Status status)
        {
            Status _status = Database.Statues.FirstOrDefault(x => x.ID == status.ID);
            _status.Name = status.Name;
            _status.ID = status.ID;
            _status.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public JsonResult Delete(int ID)
        {
            Status _status = Database.Statues.Find(ID);
            _status.IsDelete = true;
            _status.DeletedDate = DateTime.Now;
            db.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Status _status = Database.Statues.Find(ID);
            _status.IsActive = !_status.IsActive;
            db.SaveChanges();
            return Json(_status.IsActive);
        }
    }
}