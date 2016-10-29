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
    public class IsinmaController : BaseController
    {
        // GET: Admin/Isınma
        public ActionResult Index()
        {
            List<Isinma> _ısınma = Database.Isınmalar.Where(x => x.IsDelete == false).ToList();
            return View(_ısınma);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Isinma _ısınma)
        {
            _ısınma.IsDelete = false;
            _ısınma.CreatedDate = DateTime.Now;
            _ısınma.UpdatedDate = DateTime.Now;
            _ısınma.IsActive = true;
            
            Database.Isınmalar.Add(_ısınma);
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            Isinma _ısınma = Database.Isınmalar.FirstOrDefault(x => x.ID == ID);
            return View(_ısınma);

        }

        [HttpPost]
        public ActionResult Edit(Isinma _ısınma)
        {

            Isinma ısınma = Database.Isınmalar.FirstOrDefault(x => x.ID == _ısınma.ID);

         

            ısınma.Name = _ısınma.Name;
            ısınma.ID = _ısınma.ID;
            ısınma.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");


        }


        public JsonResult Delete(int ID)
        {
            Isinma _ısınma = Database.Isınmalar.Find(ID);
            _ısınma.IsDelete = true;
            _ısınma.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Isinma _ısınma = Database.Isınmalar.Find(ID);
            _ısınma.IsActive = !_ısınma.IsActive;
            Database.SaveChanges();
            return Json(_ısınma.IsActive);
        }
    }
}
