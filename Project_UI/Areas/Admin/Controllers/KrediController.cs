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
    public class KrediController : BaseController
    {
        // GET: Admin/Kredi
        public ActionResult Index()
        {
            List<Kredi> _kredi = Database.Krediler.Where(x => x.IsDelete == false).ToList();
            return View(_kredi);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Kredi _kredi)
        {
           _kredi.IsDelete = false;
           _kredi.CreatedDate = DateTime.Now;
           _kredi.UpdatedDate = DateTime.Now;
           _kredi.IsActive = true;

            Database.Krediler.Add(_kredi);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Kredi _kredi = Database.Krediler.FirstOrDefault(x => x.ID == ID);
            return View(_kredi);

        }

        [HttpPost]
        public ActionResult Edit(Kredi _kredi)
        {

            Kredi kredi = Database.Krediler.FirstOrDefault(x => x.ID == _kredi.ID);



            kredi.Name = _kredi.Name;
            kredi.ID = _kredi.ID;
            kredi.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");


        }


        public JsonResult Delete(int ID)
        {
            Kredi _kredi = Database.Krediler.Find(ID);
            _kredi.IsDelete = true;
            _kredi.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Kredi _kredi = Database.Krediler.Find(ID);
            _kredi.IsActive = !_kredi.IsActive;
            Database.SaveChanges();
            return Json(_kredi.IsActive);
        }
    }
}
