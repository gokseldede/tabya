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
    public class EsyaController : BaseController
    {
        // GET: Admin/Esya
        public ActionResult Index()
        {
            List<Esya> _esya = Database.Esyalar.Where(x => x.IsDelete == false).ToList();
            return View(_esya);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Esya _esya)
        {
            _esya.IsDelete = false;
            _esya.CreatedDate = DateTime.Now;
            _esya.UpdatedDate = DateTime.Now;
            _esya.IsActive = true;

            Database.Esyalar.Add(_esya);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Esya _esya = Database.Esyalar.FirstOrDefault(x => x.ID == ID);
            return View(_esya);

        }

        [HttpPost]
        public ActionResult Edit(Esya _esya)
        {

            Esya esya = Database.Esyalar.FirstOrDefault(x => x.ID == _esya.ID);
            
            esya.Name = _esya.Name;
            esya.ID = _esya.ID;
            esya.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");


        }


        public JsonResult Delete(int ID)
        {
            Esya _esya = Database.Esyalar.Find(ID);
            _esya.IsDelete = true;
            _esya.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Esya _esya = Database.Esyalar.Find(ID);
            _esya.IsActive = !_esya.IsActive;
            Database.SaveChanges();
            return Json(_esya.IsActive);
        }
    }
}
