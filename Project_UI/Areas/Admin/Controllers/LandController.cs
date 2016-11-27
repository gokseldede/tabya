using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Entity;
using Project_UI.Areas.Admin.Models;
using System.IO;
using System.Net;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_BLL.ServiceModels;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class LandController : BaseController
    {
        private readonly IStandartService<LandServiceModel> _landService;
        private readonly IFileService<LandFileDetail> _landFileService;
        private readonly IOptionService _optionService;

        public LandController()
        {
            _landService = new LandService();
            _optionService = new OptionsService();
            _landFileService = new FileDetailService<LandFileDetail>();
        }

        public ActionResult Index()
        {
            List<LandServiceModel> land = _landService.GetAll().ToList();
            return View(land);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var vm = GetModel();
            return View(vm);
        }

        private LandViewModel GetModel(LandViewModel viewModel = null)
        {
            if (viewModel == null)
                viewModel = new LandViewModel();


            viewModel.ExpertList = _optionService.GetExpertList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList();
            viewModel.StatusList = _optionService.GetStatuslist().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList();
            viewModel.KimdenList = _optionService.GetKimdenList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList();
            viewModel.KurlarList = _optionService.GetKurlarList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList();
            viewModel.KrediList =
                _optionService.GetKrediList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.IlList =
                _optionService.GetIllerList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.ImarStatusList = _optionService.GetImarList().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value }).ToList();
            viewModel.FileDetails = new List<FileDetailServiceModel>();

            return viewModel;
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LandViewModel land, HttpPostedFileBase document)
        {
            if (ModelState.IsValid)
            {
                var imagePath = Functions.UploadImage(document);
                land.ThumbPath = imagePath;

                var fileDetails = UploadFiles();

                LandServiceModel model = new LandServiceModel()
                {
                    Id = land.Id,
                    AdaNo = land.AdaNo,
                    Description = land.Description,
                    Emsal = land.Emsal,
                    ExpertId = land.ExpertId,
                    Gabari = land.Gabari,
                    ImarId = land.ImarId,
                    KatKarsiligi = land.KatKarsiligi,
                    KimdenId = land.KimdenId,
                    KrediId = land.KrediId,
                    KurlarId = land.KurlarId,
                    Name = land.Name,
                    PaftaNo = land.PaftaNo,
                    ParselNo = land.ParselNo,
                    Price = land.Price,
                    PriceForM2 = land.PriceForM2,
                    Size = land.Size,
                    StatusId = land.StatusId,
                    Takas = land.Takas,
                    TapuDurumu = land.TapuDurumu,
                    ThumbPath = land.ThumbPath,
                    FileDetails = fileDetails,
                    SemtId = land.SemtId
                };
                _landService.Create(model);
                return Redirect("/Admin/AdDetails/Index");
            }
            return View(GetModel(land));
        }



        public ActionResult Edit(int id)
        {
            LandViewModel vm = GetModel();
            var land = _landService.GetById(id);

            vm.Id = land.Id;
            vm.AdaNo = land.AdaNo;
            vm.Description = land.Description;
            vm.Emsal = land.Emsal;
            vm.ExpertId = land.ExpertId;
            vm.Gabari = land.Gabari;
            vm.ImarId = land.ImarId;
            vm.KatKarsiligi = land.KatKarsiligi;
            vm.KimdenId = land.KimdenId;
            vm.KrediId = land.KrediId;
            vm.KurlarId = land.KurlarId;
            vm.Name = land.Name;
            vm.PaftaNo = land.PaftaNo;
            vm.ParselNo = land.ParselNo;
            vm.Price = land.Price;
            vm.PriceForM2 = land.PriceForM2;
            vm.Size = land.Size;
            vm.StatusId = land.StatusId;
            vm.Takas = land.Takas;
            vm.TapuDurumu = land.TapuDurumu;
            vm.ThumbPath = land.ThumbPath;
            vm.FileDetails = land.FileDetails;
            vm.IlId = land.IlId;
            vm.IlceId = land.IlceId;
            vm.SemtId = land.SemtId.Value;

            TempData["ThumbPath"] = land.ThumbPath;

            return View(vm);
        }



        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LandViewModel land, HttpPostedFileBase document)
        {

            if (ModelState.IsValid)
            {
                if (document != null)
                {
                    var imagePath = Functions.UploadImage(document);
                    land.ThumbPath = imagePath;
                }
                else
                    land.ThumbPath = TempData["ThumbPath"].ToString();

                var fileDetails = UploadFiles();

                LandServiceModel model = new LandServiceModel()
                {
                    Id = land.Id,
                    AdaNo = land.AdaNo,
                    Description = land.Description,
                    Emsal = land.Emsal,
                    ExpertId = land.ExpertId,
                    Gabari = land.Gabari,
                    ImarId = land.ImarId,
                    KatKarsiligi = land.KatKarsiligi,
                    KimdenId = land.KimdenId,
                    KrediId = land.KrediId,
                    KurlarId = land.KurlarId,
                    Name = land.Name,
                    PaftaNo = land.PaftaNo,
                    ParselNo = land.ParselNo,
                    Price = land.Price,
                    PriceForM2 = land.PriceForM2,
                    Size = land.Size,
                    StatusId = land.StatusId,
                    Takas = land.Takas,
                    TapuDurumu = land.TapuDurumu,
                    ThumbPath = land.ThumbPath,
                    FileDetails = fileDetails,
                    SemtId = land.SemtId
                };
                _landService.Edit(model);

                return Redirect("/Admin/AdDetails/Index");
            }
            return View(GetModel(land));
        }


        public JsonResult Delete(int id)
        {
            try
            {
                _landService.DeleteById(id);
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
                FileDetailServiceModel fileDetail = _landFileService.GetById(Guid.Parse(id));
                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _landFileService.DeleteById(Guid.Parse(id));
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
                _landService.ChangeStatus(id);
                var status = _landService.GetById(id);
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
                _landService.ChangeVitrin(id);
                var status = _landService.GetById(id);
                return Json(new { result = true, status = status.IsInVitrin });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}
