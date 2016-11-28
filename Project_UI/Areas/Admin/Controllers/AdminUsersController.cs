using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using Project_UI.Areas.Admin.Models;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class AdminUsersController : Controller
    {
        private readonly IStandartService<AdminUser> _adminUserService;

        public AdminUsersController()
        {
            _adminUserService = new AdminUserService();
        }

        public ActionResult Index()
        {
            List<AdminUserViewModel> adminUsers = _adminUserService.GetAll().Select(adminUser => new AdminUserViewModel()
            {
                Id = adminUser.ID,
                IsActive = adminUser.IsActive,
                Name = adminUser.Name,
                CreatedDate = adminUser.CreatedDate,
                UpdatedDate = adminUser.UpdatedDate,
                ImagePath = adminUser.ImagePath,
                Email = adminUser.Email,
                PhoneNumber = adminUser.PhoneNumber,
                Surname = adminUser.Surname
            }).ToList();
            return View(adminUsers);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(AdminUserViewModel adminUser)
        {
            try
            {
                var user = new AdminUser()
                {
                    ID = adminUser.Id,
                    Name = adminUser.Name,
                    ImagePath = adminUser.ImagePath,
                    Email = adminUser.Email,
                    PhoneNumber = adminUser.PhoneNumber,
                    Surname = adminUser.Surname
                };
                _adminUserService.Create(user);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Admin/AdminUsers/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var adminUser = _adminUserService.GetById(id);
                var viewModel = new AdminUserViewModel()
                {
                    Id = adminUser.ID,
                    IsActive = adminUser.IsActive,
                    Name = adminUser.Name,
                    CreatedDate = adminUser.CreatedDate,
                    UpdatedDate = adminUser.UpdatedDate,
                    ImagePath = adminUser.ImagePath,
                    Email = adminUser.Email,
                    PhoneNumber = adminUser.PhoneNumber,
                    Surname = adminUser.Surname
                };
                return View(viewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public ActionResult Edit(AdminUserViewModel adminUser)
        {
            try
            {
                var user = new AdminUser()
                {
                    ID = adminUser.Id,
                    IsActive = adminUser.IsActive,
                    Name = adminUser.Name,
                    CreatedDate = adminUser.CreatedDate,
                    UpdatedDate = adminUser.UpdatedDate,
                    ImagePath = adminUser.ImagePath,
                    Email = adminUser.Email,
                    PhoneNumber = adminUser.PhoneNumber,
                    Surname = adminUser.Surname
                };
                _adminUserService.Edit(user);
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
                _adminUserService.DeleteById(id);
                return Json(new { result = true });
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }
        }

        public JsonResult Status(int id)
        {
            try
            {
                _adminUserService.ChangeStatus(id);
                var status = _adminUserService.GetById(id);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
