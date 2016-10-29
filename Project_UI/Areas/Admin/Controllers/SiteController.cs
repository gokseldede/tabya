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
    public class SiteController : BaseController
    {
        // GET: Admin/Site
        public ActionResult Index()
        {
            List<Site> _site = Database.Site.Where(x => x.IsDelete == false).ToList();
            return View(_site);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Site _site)
        {
            _site.IsDelete = false;
            _site.CreatedDate = DateTime.Now;
            _site.UpdatedDate = DateTime.Now;
            _site.IsActive = true;

            Database.Site.Add(_site);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Site _site = Database.Site.FirstOrDefault(x => x.ID == ID);
            return View(_site);

        }

        [HttpPost]
        public ActionResult Edit(Site _site)
        {

            Site site = Database.Site.FirstOrDefault(x => x.ID == _site.ID);

            site.Name = _site.Name;
            site.ID = _site.ID;
            site.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");


        }


        public JsonResult Delete(int ID)
        {
            Site _site = Database.Site.Find(ID);
            _site.IsDelete = true;
            _site.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Site _site = Database.Site.Find(ID);
            _site.IsActive = !_site.IsActive;
            Database.SaveChanges();
            return Json(_site.IsActive);
        }
    }
}