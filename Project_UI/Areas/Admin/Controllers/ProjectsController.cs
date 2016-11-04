using System;
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
using Project_BLL.ViewModels;
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
            List<ProjectViewModel> _project = _projectService.GetAll().Select(x => new ProjectViewModel()
            {
                Id=x.Id,
                Name=x.Name,
                ProjectFirm=x.ProjectFirm,
                ProjectDeliveryDate = x.ProjectDeliveryDate,
                IsActive=x.IsActive,
                CreatedDateTime=x.CreatedDateTime,
                UpdatedDateTime=x.UpdatedDateTime
            }).ToList();
            return View(_project);
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
                ProjectFiles = new List<FileDetailServiceModel>()
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
                List<FileDetailServiceModel> fileDetails = new List<FileDetailServiceModel>();
                for (int i = 2; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetailServiceModel fileDetail = new FileDetailServiceModel()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }

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
            model.ProjectFiles = vm.ProjectFileDetails;
            model.ProjectDeliveryDate = vm.ProjectDeliveryDate;
            model.ProjectArea = vm.ProjectArea;

            return View(model);

        }

        // POST: Admin/Projects/Edit/5

        [HttpPost, ValidateInput(false)]

        public ActionResult Edit(Project project, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document, HttpPostedFileBase pricelist)
        {

            //Project _project = Database.Projects.FirstOrDefault(x => x.ID == project.ID);

            //if (document != null)
            //{
            //    var imagePath = Functions.UploadImage(document);
            //    _project.ImagePath = imagePath;
            //}
            //else
            //{
            //    _project.ImagePath = TempData["ImagePath"].ToString();
            //}
            //if (pricelist != null)
            //{
            //    var price = Functions.UploadImage(pricelist);
            //    _project.PriceList = price;
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
            //if (ModelState.IsValid)
            //{
            //    for (int i = 2; i < Request.Files.Count; i++)
            //    {
            //        var file = Request.Files[i];

            //        if (file != null && file.ContentLength > 0)
            //        {
            //            var fileName = Path.GetFileName(file.FileName);
            //            ProjectFile fileDetail = new ProjectFile()
            //            {
            //                FileName = fileName,
            //                Extension = Path.GetExtension(fileName),
            //                Id = Guid.NewGuid(),
            //                ProjectID = project.ID
            //            };
            //            var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
            //            file.SaveAs(path);

            //            Database.Entry(fileDetail).State = EntityState.Added;
            //        }
            //    }
            //    Database.Entry(_project).State = EntityState.Modified;
            //    _project.ID = project.ID;
            //    _project.UpdatedDate = DateTime.Now;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
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
    }
}
