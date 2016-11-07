using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class ContactsController : Controller
    {

        private readonly IStandartService<Contact> _contanctService;

        public ContactsController()
        {
            _contanctService = new ContanctService();
        }
        
        public ActionResult Index()
        {
            List<Contact> contacs = _contanctService.GetAll().ToList();
            return View(contacs);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                _contanctService.Create(contact);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Admin/Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Contact contact = _contanctService.GetById(id);
                return View(contact);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                _contanctService.Edit(contact);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult Delete(int id)
        {
            try
            {
                _contanctService.DeleteById(id);
                return Json(new { result = true});
            }
            catch (Exception)
            {
                return Json(new { result = true });
            }
        }

        public JsonResult Status(int id)
        {
            try
            {
                _contanctService.ChangeStatus(id);
                var status = _contanctService.GetById(id);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
