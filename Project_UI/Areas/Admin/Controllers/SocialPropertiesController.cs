using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class SocialPropertiesController : BaseController
    {
        // GET: Admin/SocialProperties
        public ActionResult Index()
        {
            List<SocialApps> _socialapps = Database.SocialApps.Where(x => x.IsDelete == false).ToList();
            return View(_socialapps);
        }

        // GET: Admin/Social/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Social/Create
        [HttpPost]
        public ActionResult Create(SocialApps socialapps)
        {

            socialapps.IsDelete = false;
            socialapps.CreatedDate = DateTime.Now;
            socialapps.UpdatedDate = DateTime.Now;
            socialapps.IsActive = true;

            db.SocialApps.Add(socialapps);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Social/Edit/5
        public ActionResult Edit(int ID)
        {
            SocialApps socialapps = Database.SocialApps.FirstOrDefault(x => x.ID == ID);
            return View(socialapps);
        }

        // POST: Admin/Social/Edit/5

        [HttpPost]
        public ActionResult Edit(SocialApps socialapps)
        {
            SocialApps _socialapps = Database.SocialApps.FirstOrDefault(x => x.ID == socialapps.ID);
            _socialapps.Name = socialapps.Name;
            _socialapps.ID = socialapps.ID;
            _socialapps.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public JsonResult Delete(int ID)
        {
            SocialApps _socialapps = db.SocialApps.Find(ID);
            _socialapps.IsDelete = true;
            _socialapps.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            SocialApps _socialapps = db.SocialApps.Find(ID);
            _socialapps.IsActive = !_socialapps.IsActive;
            Database.SaveChanges();
            return Json(_socialapps.IsActive);
        }
    }
}