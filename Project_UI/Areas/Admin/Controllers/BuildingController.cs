using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using Project_UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_BLL.ServiceModels;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class BuildingController : BaseController
    {

        private readonly IStandartService<BuildingServiceModel> _buildingService;
        private readonly IFileService<BinaFileDetail> _buildingFileService;
        private readonly IOptionService _optionService;

        public BuildingController()
        {
            _buildingService = new BuildingService();
            _optionService = new OptionsService();
            _buildingFileService = new FileDetailService<BinaFileDetail>();
        }

        public ActionResult Index()
        {
            List<BuildingServiceModel> bina = _buildingService.GetAll().ToList();
            return View(bina);
        }

        [HttpGet]
        public ActionResult Create()
        {
            BuildingViewModel vm = GetModel();
            return View(vm);
        }

        private BuildingViewModel GetModel(BuildingViewModel viewModel = null)
        {
            if (viewModel == null)
                viewModel = new BuildingViewModel();

            viewModel.ExpertList = _optionService.GetExpertList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList();
            viewModel.KimdenList = _optionService.GetKimdenList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList();
            viewModel.KurlarList = _optionService.GetKurlarList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList();
            viewModel.PropertiesList =
                _optionService.GetPropertiesList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.SecuritiesList =
                _optionService.GetSecurityList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.SocialList =
                _optionService.GetSocialAppsList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.StatusList =
                _optionService.GetStatuslist()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.IlList =
                _optionService.GetIllerList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.FileDetails = new List<FileDetailServiceModel>();

            return viewModel;
        }
        public ActionResult Edit(int id)
        {
            BuildingViewModel vm = GetModel();
            var building = _buildingService.GetById(id);

            vm.Id = building.Id;
            vm.Name = building.Name;
            vm.BAge = building.BAge;
            vm.Size = building.Size;
            vm.FloorFlatCount = building.FloorFlatCount;
            vm.FloorCount = building.FloorCount;
            vm.Takas = building.Takas;
            vm.Price = building.Price;
            vm.ThumbPath = building.ThumbPath;
            vm.Description = building.Description;

            vm.ExpertId = building.ExpertId;
            vm.KurlarId = building.KurlarId;
            vm.StatusId = building.StatusId;
            vm.KimdenId = building.KimdenId;
            vm.FileDetails = building.FileDetails;

            vm.SelectedProperties = building.SelectedProperties.Select(x => x.Id.ToString()).ToArray();
            vm.SelectedSecurities = building.SelectedSecurities.Select(x => x.Id.ToString()).ToArray();
            vm.SelectedSocialList = building.SelectedSocialApps.Select(x => x.Id.ToString()).ToArray();

            TempData["ImagePath"] = building.ThumbPath;

            return View(vm);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuildingViewModel bina, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {
            if (ModelState.IsValid)
            {
                var imagePath = Functions.UploadImage(document);
                bina.ThumbPath = imagePath;

                List<FileDetailServiceModel> fileDetails = UploadFiles();

                BuildingServiceModel model = new BuildingServiceModel
                {
                    Id = bina.Id,
                    BAge = bina.BAge,
                    Description = bina.Description,
                    ExpertId = bina.ExpertId,
                    FloorCount = bina.FloorCount,
                    FloorFlatCount = bina.FloorFlatCount,
                    KimdenId = bina.KimdenId,
                    KurlarId = bina.KurlarId,
                    Name = bina.Name,
                    Price = bina.Price,
                    Size = bina.Size,
                    StatusId = bina.StatusId,
                    Takas = bina.Takas,
                    ThumbPath = bina.ThumbPath,
                    FileDetails = fileDetails,
                    SemtId = bina.SemtId,
                    SelectedSecurities = securitys.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedSocialApps = socials.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedProperties = tags.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList()
                };
                _buildingService.Create(model);
                return Redirect("/Admin/AdDetails/Index");
            }
            return View(GetModel(bina));
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BuildingViewModel bina, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {

            if (ModelState.IsValid)
            {
                if (document != null)
                {
                    var imagePath = Functions.UploadImage(document);
                    bina.ThumbPath = imagePath;
                }
                else
                    bina.ThumbPath = TempData["ImagePath"].ToString();

                List<FileDetailServiceModel> fileDetails = UploadFiles();

                BuildingServiceModel model = new BuildingServiceModel
                {
                    Id = bina.Id,
                    BAge = bina.BAge,
                    Description = bina.Description,
                    ExpertId = bina.ExpertId,
                    FloorCount = bina.FloorCount,
                    FloorFlatCount = bina.FloorFlatCount,
                    KimdenId = bina.KimdenId,
                    KurlarId = bina.KurlarId,
                    Name = bina.Name,
                    Price = bina.Price,
                    Size = bina.Size,
                    StatusId = bina.StatusId,
                    Takas = bina.Takas,
                    ThumbPath = bina.ThumbPath,
                    FileDetails = fileDetails,
                    SemtId = bina.SemtId,
                    SelectedSecurities = securitys.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedSocialApps = socials.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedProperties = tags.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList()
                };
                _buildingService.Edit(model);
                return Redirect("/Admin/AdDetails/Index");
            }
            return View(GetModel(bina));
        }

        public JsonResult Delete(int id)
        {
            try
            {
                _buildingService.DeleteById(id);
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
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = false, Message = "Bad Request" });
            }
            try
            {
                FileDetailServiceModel fileDetail = _buildingFileService.GetById(Guid.Parse(id));
                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _buildingFileService.DeleteById(Guid.Parse(id));
                return Json(new { Result = true });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult Status(int id)
        {
            try
            {
                _buildingService.ChangeStatus(id);
                var status = _buildingService.GetById(id);
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
                _buildingService.ChangeVitrin(id);
                var status = _buildingService.GetById(id);
                return Json(new { result = true, status = status.IsInVitrin });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}