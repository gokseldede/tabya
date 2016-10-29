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
    public class AdminUsersController : BaseController
    {


        // GET: Admin/AdminUsers
        public ActionResult Index()
        {
            List<AdminUser> _AdminUsers = Database.AdminUsers.Where(x => x.IsDelete == false).ToList();
            return View(_AdminUsers);

        }



        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(AdminUser adminUser)
        {
            adminUser.IsDelete = false;
            adminUser.CreatedDate = DateTime.Now;
            adminUser.UpdatedDate = DateTime.Now;
            adminUser.IsActive = true;

            db.AdminUsers.Add(adminUser);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/AdminUsers/Edit/5
        public ActionResult Edit(int ID)
        {

            AdminUser adminUser = Database.AdminUsers.FirstOrDefault(x => x.ID == ID);

            return View(adminUser);
        }


        [HttpPost]
        public ActionResult Edit(AdminUser adminUser)
        {
            AdminUser _adminUser = Database.AdminUsers.FirstOrDefault(x => x.ID == adminUser.ID);
            _adminUser.Name = adminUser.Name;
            _adminUser.PhoneNumber = adminUser.PhoneNumber;
            _adminUser.Password = adminUser.Password;
            _adminUser.ID = adminUser.ID;
            _adminUser.UpdatedDate = DateTime.Now;
            db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: Admin/AdminUsers/Delete/5
        public JsonResult Delete(int ID)
        {
            AdminUser _adminUser = Database.AdminUsers.Find(ID);
            _adminUser.IsDelete = true;
            _adminUser.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            AdminUser _adminUser = Database.AdminUsers.Find(ID);
            _adminUser.IsActive = !_adminUser.IsActive;
            Database.SaveChanges();
            return Json(_adminUser.IsActive);
        }
    }
}
