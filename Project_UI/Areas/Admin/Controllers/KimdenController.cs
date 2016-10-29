using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class KimdenController : BaseController
    {
        // GET: Admin/Kimden
        public ActionResult Index()
        {
            List<Kimden> _kimden = Database.Kimden.Where(x => x.IsDelete == false).ToList();
            return View(_kimden);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Kimden _kimden)
        {
            _kimden.IsDelete = false;
            _kimden.CreatedDate = DateTime.Now;
            _kimden.UpdatedDate = DateTime.Now;
            _kimden.IsActive = true;

            Database.Kimden.Add(_kimden);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Kimden _kimden = Database.Kimden.FirstOrDefault(x => x.ID == ID);
            return View(_kimden);

        }

        [HttpPost]
        public ActionResult Edit(Kimden _kimden)
        {

            Kimden kimden = Database.Kimden.FirstOrDefault(x => x.ID == _kimden.ID);
            kimden.Name = _kimden.Name;
            kimden.ID = _kimden.ID;
            kimden.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");


        }


        public JsonResult Delete(int ID)
        {
            Kimden _kimden = Database.Kimden.Find(ID);
            _kimden.IsDelete = true;
            _kimden.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Kimden _kimden = Database.Kimden.Find(ID);
            _kimden.IsActive = !_kimden.IsActive;
            Database.SaveChanges();
            return Json(_kimden.IsActive);
        }
    }
}