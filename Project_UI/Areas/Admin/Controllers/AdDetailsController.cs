using System;
using System.Collections.Generic;
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
    public class AdDetailsController : BaseController
    {
        private readonly IFileService<FileDetail> _adFileService;
        private readonly IAdService _adService;
        private readonly IOptionService _optionService;

        public AdDetailsController()
        {
            _adService = new AdService();
            _optionService = new OptionsService();
            _adFileService = new FileDetailService<FileDetail>();
        }

        public ActionResult Index()
        {
            AdListViewModel vm = new AdListViewModel();
            vm.AdDetails = _adService.GetAll().ToList();
            vm.Workplaces = _adService.GetWorkPlaces();
            vm.Lands = _adService.GetLands();
            vm.Binas = _adService.GetBuildings();
            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = GetModel();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var adDetail = GetModel();
            var work = _adService.GetById(id);

            adDetail.BAge = work.BAge;
            adDetail.BathroomCount = work.BathroomCount;
            adDetail.Description = work.Description;
            adDetail.Dues = work.Dues;
            adDetail.EmlakTipId = work.EmlakTipId;
            adDetail.EsyaId = work.EsyaId;
            adDetail.FlatFloor = work.FlatFloor;
            adDetail.ExpertId = work.ExpertId;
            adDetail.FloorCount = work.FloorCount;
            adDetail.IsinmaId = work.IsinmaId;
            adDetail.KimdenId = work.KimdenId;
            adDetail.KrediId = work.KrediId;
            adDetail.KullanimId = work.KullanimId;
            adDetail.KurlarId = work.KurlarId;
            adDetail.Name = work.Name;
            adDetail.Price = work.Price;
            adDetail.RoomCount = work.RoomCount;
            adDetail.SiteId = work.SiteId;
            adDetail.Size = work.Size;
            adDetail.StatusId = work.StatusId;
            adDetail.ThumbPath = work.ThumbPath;
            adDetail.FileDetails = work.FileDetails;
            adDetail.Id = work.Id;
            adDetail.SelectedProperties = work.SelectedProperties.Select(x=>x.Id.ToString()).ToArray();
            adDetail.SelectedSecurities = work.SelectedSecurities.Select(x => x.Id.ToString()).ToArray();
            adDetail.SelectedSocialList = work.SelectedSocialApps.Select(x => x.Id.ToString()).ToArray();

            TempData["ImagePath"] = adDetail.ThumbPath;

            return View(adDetail);
        }

        private AdDetailViewModel GetModel()
        {
            var viewModel = new AdDetailViewModel()
            {
                ExpertList = _optionService.GetExpertList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                IsinmaList = _optionService.GetIsinmaList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                KimdenList = _optionService.GetKimdenList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                KrediList = _optionService.GetKrediList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                KurlarList = _optionService.GetKurlarList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                PropertiesList = _optionService.GetPropertiesList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                SecuritiesList = _optionService.GetSecurityList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                SocialList = _optionService.GetSocialAppsList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                StatusList = _optionService.GetStatuslist().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                IlList = _optionService.GetIllerList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                EmlakTipList = _optionService.GetEmlakTipList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                EsyaList = _optionService.GetEsyaList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                SiteList = _optionService.GetSiteList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                KullanimList = _optionService.GetKullanimList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList(),
                FileDetails = new List<FileDetailServiceModel>()
            };
            return viewModel;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(AdDetailViewModel adDetail, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {
           
            if (ModelState.IsValid)
            {
                var imagePath = Functions.UploadImage(document);
                adDetail.ThumbPath = imagePath;

                var fileDetails = UploadFiles();

                AdDetailServiceModel model = new AdDetailServiceModel()
                {
                    BAge = adDetail.BAge,
                    BathroomCount = adDetail.BathroomCount,
                    Description = adDetail.Description,
                    Dues = adDetail.Dues,
                    EmlakTipId = adDetail.EmlakTipId,
                    EsyaId = adDetail.EsyaId,
                    FlatFloor = adDetail.FlatFloor,
                    ExpertId = adDetail.ExpertId,
                    FloorCount = adDetail.FloorCount,
                    IsinmaId = adDetail.IsinmaId,
                    KimdenId = adDetail.KimdenId,
                    KrediId = adDetail.KrediId,
                    KullanimId = adDetail.KullanimId,
                    KurlarId = adDetail.KurlarId,
                    Name = adDetail.Name,
                    Price = adDetail.Price,
                    RoomCount = adDetail.RoomCount,
                    SiteId = adDetail.SiteId,
                    Size = adDetail.Size,
                    StatusId = adDetail.StatusId,
                    ThumbPath = adDetail.ThumbPath,
                    FileDetails = fileDetails,
                    SelectedProperties = tags.Select(x=>new SelectlistItem() {Id=int.Parse(x)}).ToList(),
                    SelectedSecurities=securitys.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedSocialApps = socials.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList()
                };
                _adService.Create(model);
            }
            return Redirect("Index");
        }

      

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(AdDetailViewModel adDetail, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {
           
            if (ModelState.IsValid)
            {
                if (document != null)
                {
                    var imagePath = Functions.UploadImage(document);
                    adDetail.ThumbPath = imagePath;
                }
                else
                    adDetail.ThumbPath = TempData["ImagePath"].ToString();

                var files = UploadFiles();

                AdDetailServiceModel model = new AdDetailServiceModel()
                {
                    BAge = adDetail.BAge,
                    BathroomCount = adDetail.BathroomCount,
                    Description = adDetail.Description,
                    Dues = adDetail.Dues,
                    EmlakTipId = adDetail.EmlakTipId,
                    EsyaId = adDetail.EsyaId,
                    FlatFloor = adDetail.FlatFloor,
                    ExpertId = adDetail.ExpertId,
                    FloorCount = adDetail.FloorCount,
                    IsinmaId = adDetail.IsinmaId,
                    KimdenId = adDetail.KimdenId,
                    KrediId = adDetail.KrediId,
                    KullanimId = adDetail.KullanimId,
                    KurlarId = adDetail.KurlarId,
                    Name = adDetail.Name,
                    Price = adDetail.Price,
                    RoomCount = adDetail.RoomCount,
                    SiteId = adDetail.SiteId,
                    Size = adDetail.Size,
                    StatusId = adDetail.StatusId,
                    ThumbPath = adDetail.ThumbPath,
                    FileDetails = files,
                    SelectedSecurities = securitys.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedProperties = tags.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedSocialApps = socials.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    Id = adDetail.Id
                };
                _adService.Edit(model);

                return RedirectToAction("Index");
            }
            return View(adDetail);
        }

        public JsonResult Delete(int id)
        {
            try
            {
                _adService.DeleteById(id);
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
                FileDetailServiceModel fileDetail = _adFileService.GetById(Guid.Parse(id));
                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _adFileService.DeleteById(Guid.Parse(id));
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
                _adService.ChangeStatus(id);
                var status = _adService.GetById(id);
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
                _adService.ChangeVitrin(id);
                var status = _adService.GetById(id);
                return Json(new { result = true, status = status.IsInVitrin });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
