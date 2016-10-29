using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_DAL;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class SlidersController : BaseController
    {


        // GET: Admin/Sliders
        public ActionResult Index()
        {
            List<Slider> _slider = Database.Sliders.Where(x => x.IsDelete == false || x.IsActive == false).ToList();
            return View(_slider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Slider _slider)
        {
            _slider.IsDelete = false;
            _slider.CreatedDate = DateTime.Now;
            _slider.UpdatedDate = DateTime.Now;
            _slider.IsActive = true;

            db.Sliders.Add(_slider);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int id)
        {
            Slider _slider = Database.Sliders.FirstOrDefault(x => x.ID == id);
            return View(_slider);
        }

        [HttpPost]
        public ActionResult Edit(Slider _slider)
        {
            Slider slider = Database.Sliders.FirstOrDefault(x => x.ID == _slider.ID);

            slider.Header = _slider.Header;
            slider.SubText = _slider.SubText;
            slider.Text = _slider.Text;
            slider.ID = _slider.ID;
            slider.UpdatedDate = DateTime.Now;
            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Sliders/Delete/5
        public JsonResult Delete(int ID)
        {
            Slider _slider = Database.Sliders.Find(ID);
            _slider.IsDelete = true;
            _slider.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Slider _slider = Database.Sliders.Find(ID);
            _slider.IsActive = !_slider.IsActive;
            Database.SaveChanges();
            return Json(_slider.IsActive);
        }
    }
}
