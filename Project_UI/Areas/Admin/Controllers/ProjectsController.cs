﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Entity;
using Project_UI.Areas.Admin.Models;
using System.IO;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_BLL.ServiceModels;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class ProjectsController : BaseController
    {

        private readonly IFileService<ProjectFile> _workFileService;
        private readonly IOptionService _optionService;
        private readonly IStandartService<ProjectServiceModel> _projectService;

        public ProjectsController()
        {
            _optionService = new OptionsService();
            _workFileService = new FileDetailService<ProjectFile>();
            _projectService = new ProjectService();
        }

        // GET: Admin/Projects
        public ActionResult Index()
        {
            List<ProjectServiceModel> project = _projectService.GetAll().ToList();
            return View(project);
        }


        // GET: Admin/Projects/Create
        public ActionResult Create()
        {
            var model = GetModel();
            return View(model);
        }

        private ProjectViewModel GetModel()
        {
            var viewModel = new ProjectViewModel()
            {
                ExpertList = _optionService.GetExpertList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                PropertiesList = _optionService.GetPropertiesList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                SecuritiesList = _optionService.GetSecurityList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                SocialList = _optionService.GetSocialAppsList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                FileDetails = new List<FileDetailServiceModel>()
            };
            return viewModel;
        }

        // POST: Admin/Projects/Create

        [HttpPost, ValidateInput(false)]

        public ActionResult Create(ProjectViewModel project, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document, HttpPostedFileBase pricelist)
        {

            //GetExpert();
            //GetProperties();
            //GetSecurity();
            //GetSocialApps();
            //project.IsDelete = false;
            //project.CreatedDate = DateTime.Now;
            //project.UpdatedDate = DateTime.Now;
            //project.IsActive = true;


            //var imagePath = Functions.UploadImage(document);

            //project.ImagePath = imagePath;
            //var price = Functions.UploadImage(pricelist);
            //project.PriceList = price;

            //foreach (var b in tags)
            //{
            //    project.properties += b + ",";
            //}
            //foreach (var c in securitys)
            //{
            //    project.securitys += c + ",";
            //}
            //foreach (var a in socials)
            //{
            //    project.socialapps += a + ",";
            //}

            if (ModelState.IsValid)
            {
                var fileDetails = FileDetailServiceModels();

                var imagePath = Functions.UploadImage(document);
                var price = Functions.UploadImage(pricelist);
                project.ThumbPath = imagePath;
                project.PriceList = price;

                ProjectServiceModel model = new ProjectServiceModel()
                {
                    Description = project.Description,
                    ExpertId = project.ExpertId,
                    FlatCount = project.FlatCount,
                    Name = project.Name,
                    PriceList = project.PriceList,
                    ProjectArea = project.ProjectArea,
                    ProjectDeliveryDate = project.ProjectDeliveryDate,
                    ProjectFileDetails = fileDetails,
                    ProjectFirm = project.ProjectFirm,
                    ProjectLocation = project.ProjectLocation,
                    ThumbPath = project.ThumbPath,
                    ProjectPromotionVideo = project.ProjectPromotionVideo
                };

                _projectService.Create(model);
            }


            return Redirect("Index");
        }

        private List<FileDetailServiceModel> FileDetailServiceModels()
        {
            List<FileDetailServiceModel> fileDetails = UploadFiles();
            return fileDetails;
        }

        public ActionResult Edit(int id)
        {
            var model = GetModel();
            var vm = _projectService.GetById(id);

            model.Id = vm.Id;
            model.PriceList = vm.PriceList;
            model.ProjectPromotionVideo = vm.ProjectPromotionVideo;
            model.ThumbPath = vm.ThumbPath;
            model.CreatedDateTime = vm.CreatedDateTime;
            model.Description = vm.Description;
            model.ExpertId = vm.ExpertId;
            model.FlatCount = vm.FlatCount;
            model.Name = vm.Name;
            model.ProjectFirm = vm.ProjectFirm;
            model.ProjectLocation = vm.ProjectLocation;
            model.FileDetails = vm.ProjectFileDetails;
            model.ProjectDeliveryDate = vm.ProjectDeliveryDate;
            model.ProjectArea = vm.ProjectArea;

            TempData["ThumbPath"] = vm.ThumbPath;
            TempData["PriceList"] = vm.PriceList;

            return View(model);

        }



        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ProjectViewModel project, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document, HttpPostedFileBase pricelist)
        {

            //Project _project = Database.Projects.FirstOrDefault(x => x.ID == project.ID);


            //else
            //{
            //    _project.ImagePath = TempData["ImagePath"].ToString();
            //}

            //else
            //{
            //    _project.PriceList = TempData["PriceList"].ToString();
            //}

            //_project.Name = project.Name;
            //_project.SubName = project.SubName;
            //_project.SSubName = project.SSubName;
            //_project.Description = project.Description;
            //_project.ProjectA = project.ProjectA;
            //_project.HouseN = project.HouseN;
            //_project.DeliveryDate = project.DeliveryDate;
            //_project.ExpertID = project.ExpertID;
            //_project.Video = project.Video;
            //if (tags != null)
            //{
            //    _project.properties = string.Empty;
            //    foreach (var b in tags)
            //    {
            //        _project.properties += b + ",";
            //    }
            //}
            //if (securitys != null)
            //{
            //    _project.securitys = string.Empty;
            //    foreach (var c in securitys)
            //    {
            //        _project.securitys += c + ",";
            //    }
            //}
            //if (socials != null)
            //{
            //    _project.socialapps = string.Empty;
            //    foreach (var a in socials)
            //    {
            //        _project.socialapps += a + ",";
            //    }
            //}
            if (ModelState.IsValid)
            {
                if (pricelist != null)
                {
                    var price = Functions.UploadImage(pricelist);
                    project.PriceList = price;
                }
                else if (TempData["PriceList"] != null)
                    project.PriceList = TempData["PriceList"].ToString();

                if (document != null)
                {
                    var imagePath = Functions.UploadImage(document);
                    project.ThumbPath = imagePath;
                }
                else if (TempData["ThumbPath"] != null)
                    project.ThumbPath = TempData["ThumbPath"].ToString();

                var fileDetails = FileDetailServiceModels();

                ProjectServiceModel model = new ProjectServiceModel()
                {
                    Description = project.Description,
                    ExpertId = project.ExpertId,
                    FlatCount = project.FlatCount,
                    Name = project.Name,
                    PriceList = project.PriceList,
                    ProjectArea = project.ProjectArea,
                    ProjectDeliveryDate = project.ProjectDeliveryDate,
                    ProjectFileDetails = fileDetails,
                    ProjectFirm = project.ProjectFirm,
                    ProjectLocation = project.ProjectLocation,
                    ThumbPath = project.ThumbPath,
                    ProjectPromotionVideo = project.ProjectPromotionVideo,
                    Id = project.Id
                };

                _projectService.Edit(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public JsonResult Delete(int id)
        {
            try
            {
                _projectService.DeleteById(id);
                return Json(new { result = true });
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }
        }


        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = false, Message = "Bad Request" });
            }
            try
            {
                FileDetailServiceModel fileDetail = _workFileService.GetById(Guid.Parse(id));
                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _workFileService.DeleteById(Guid.Parse(id));
                return Json(new { Result = true });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }

        public JsonResult Status(int id)
        {
            try
            {
                _projectService.ChangeStatus(id);
                var status = _projectService.GetById(id);
                return Json(new { result = true, status = status.IsActive });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }

        public JsonResult Vitrin(int id)
        {
            try
            {
                _projectService.ChangeVitrin(id);
                var status = _projectService.GetById(id);
                return Json(new { result = true, status = status.IsInVitrin });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
