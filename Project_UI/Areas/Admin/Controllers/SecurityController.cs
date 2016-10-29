using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class SecurityController : BaseController
    {
        // GET: Admin/Security
        public ActionResult Index()
        {
            List<Securitys> _security = Database.Security.Where(x => x.IsDelete == false).ToList();
            return View(_security);
        }

        // GET: Admin/Security/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Security/Create
        [HttpPost]
        public ActionResult Create(Securitys security)
        {

            security.IsDelete = false;
            security.CreatedDate = DateTime.Now;
            security.UpdatedDate = DateTime.Now;
            security.IsActive = true;

            db.Security.Add(security);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Security/Edit/5
        public ActionResult Edit(int ID)
        {
            Securitys security = Database.Security.FirstOrDefault(x => x.ID == ID);
            return View(security);
        }

        // POST: Admin/Security/Edit/5

        [HttpPost]
        public ActionResult Edit(Securitys security)
        {
            Securitys _security = Database.Security.FirstOrDefault(x => x.ID == security.ID);
            _security.Name = security.Name;
            _security.ID = security.ID;
            _security.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public JsonResult Delete(int ID)
        {
            Securitys _security = db.Security.Find(ID);
            _security.IsDelete = true;
            _security.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Securitys _security = db.Security.Find(ID);
            _security.IsActive = !_security.IsActive;
            Database.SaveChanges();
            return Json(_security.IsActive);
        }
    }
}