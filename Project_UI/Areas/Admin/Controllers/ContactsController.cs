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
    public class ContactsController : BaseController
    {

        //İletişim
        // GET: Admin/Contacts
        public ActionResult Index()
        {
            List<Contact> _contacs = Database.Contacts.Where(x => x.IsDelete == false).ToList();
            return View(_contacs);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            contact.IsDelete = false;
            contact.CreatedDate = DateTime.Now;
            contact.UpdatedDate = DateTime.Now;
            contact.IsActive = true;
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        // GET: Admin/Contacts/Edit/5
        public ActionResult Edit(int ID)
        {
            Contact contact = Database.Contacts.FirstOrDefault(x => x.ID == ID);
            return View(contact);
        }


        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            Contact _contact = Database.Contacts.FirstOrDefault(x => x.ID == contact.ID);
            _contact.Name = contact.Name;
            _contact.Number = contact.Number;
            _contact.Maps = contact.Maps;
            _contact.ID = contact.ID;
            _contact.UpdatedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Admin/Contacts/Delete/5
        public JsonResult Delete(int ID)
        {
            Contact _contact = Database.Contacts.Find(ID);
            _contact.IsDelete = true;
            _contact.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        public JsonResult Status(int ID)
        {
            Contact _contact = Database.Contacts.Find(ID);
            _contact.IsActive = !_contact.IsActive;
            Database.SaveChanges();
            return Json(_contact.IsActive);
        }
    }
}
