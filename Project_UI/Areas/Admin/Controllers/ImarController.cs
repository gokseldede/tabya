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
    public class ImarController : BaseController
    {
        // GET: Admin/Imar
        public ActionResult Index()
        {
            List<Imar> _imar = Database.Imar.Where(x => x.IsDelete == false).ToList();
            return View(_imar);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Imar _imar)
        {
            _imar.IsDelete = false;
            _imar.CreatedDate = DateTime.Now;
            _imar.UpdatedDate = DateTime.Now;
            _imar.IsActive = true;

            Database.Imar.Add(_imar);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Imar _imar = Database.Imar.FirstOrDefault(x => x.ID == ID);
            return View(_imar);

        }

        [HttpPost]
        public ActionResult Edit(Imar _imar)
        {

            Imar imar = Database.Imar.FirstOrDefault(x => x.ID == _imar.ID);
            imar.Name = _imar.Name;
            imar.ID = _imar.ID;
            imar.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");


        }


        public JsonResult Delete(int ID)
        {
            Imar _imar = Database.Imar.Find(ID);
            _imar.IsDelete = true;
            _imar.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Imar _imar = Database.Imar.Find(ID);
            _imar.IsActive = !_imar.IsActive;
            Database.SaveChanges();
            return Json(_imar.IsActive);
        }
    }
}