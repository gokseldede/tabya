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
    public class KullanimController : BaseController
    {
        // GET: Admin/Kullanım
        public ActionResult Index()
        {
            List<Kullanım> _kullanım = Database.Kullanımlar.Where(x => x.IsDelete == false).ToList();
            return View(_kullanım);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Kullanım _kullanım)
        {
            _kullanım.IsDelete = false;
            _kullanım.CreatedDate = DateTime.Now;
            _kullanım.UpdatedDate = DateTime.Now;
            _kullanım.IsActive = true;

            Database.Kullanımlar.Add(_kullanım);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Kullanım _kullanım = Database.Kullanımlar.FirstOrDefault(x => x.ID == ID);
            return View(_kullanım);

        }

        [HttpPost]
        public ActionResult Edit(Kullanım _kullanım)
        {

            Kullanım kullanım = Database.Kullanımlar.FirstOrDefault(x => x.ID == _kullanım.ID);
            
            kullanım.Name = _kullanım.Name;
            kullanım.ID = _kullanım.ID;
            kullanım.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");


        }


        public JsonResult Delete(int ID)
        {
            Kullanım _kullanım = Database.Kullanımlar.Find(ID);
            _kullanım.IsDelete = true;
            _kullanım.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Kullanım _kullanım = Database.Kullanımlar.Find(ID);
            _kullanım.IsActive = !_kullanım.IsActive;
            Database.SaveChanges();
            return Json(_kullanım.IsActive);
        }
    }
}
