using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
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
using Project_UI.Areas.Admin.Models;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class WorkplaceController : BaseController
    {
        //Çoklu resim yükleme
        //http://www.advancesharp.com/blog/1130/image-gallery-in-asp-net-mvc-with-multiple-file-and-size

        private readonly IStandartService<WorkplaceServiceModel> _workPlaceService;
        private readonly IFileService<WorkFileDetail> _workFileService;
        private readonly IOptionService _optionService;

        public WorkplaceController()
        {
            _workPlaceService = new WorkPlaceService();
            _optionService = new OptionsService();
            _workFileService = new FileDetailService<WorkFileDetail>();
        }
        public ActionResult Index()
        {
            List<WorkplaceServiceModel> work = _workPlaceService.GetAll().ToList();
            return View(work);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = GetModel();
            return View(viewModel);
        }

        private WorkPlaceViewModel GetModel(WorkPlaceViewModel viewModel = null)
        {
            if (viewModel == null)
                viewModel = new WorkPlaceViewModel();

            viewModel.ExpertList =
                _optionService.GetExpertList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.IsinmaList =
                _optionService.GetIsinmaList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.KimdenList =
                _optionService.GetKimdenList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.KrediList =
                _optionService.GetKrediList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
            viewModel.KurlarList =
                _optionService.GetKurlarList()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Value })
                    .ToList();
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


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkPlaceViewModel work, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {

            if (ModelState.IsValid)
            {
                List<FileDetailServiceModel> fileDetails = UploadFiles();

                work.ThumbPath = Functions.UploadImage(document);

                WorkplaceServiceModel model = new WorkplaceServiceModel()
                {
                    BAge = work.BAge,
                    Description = work.Description,
                    Dues = work.Dues,
                    ExpertId = work.ExpertId,
                    IsinmaId = work.IsinmaId,
                    KimdenId = work.KimdenId,
                    KrediId = work.KrediId,
                    KurlarId = work.KurlarId,
                    Name = work.Name,
                    Price = work.Price,
                    Room = work.Room,
                    Size = work.Size,
                    ThumbPath = work.ThumbPath,
                    StatusId = work.StatusId,
                    SemtId = work.SemtId,
                    WorkFileDetails = fileDetails,
                    SelectedSecurities = securitys.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedSocialApps = socials.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedProperties = tags.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList()
                };
                _workPlaceService.Create(model);

                return Redirect("/Admin/AdDetails/Index");
            }
            return View(work);
        }


        public ActionResult Edit(int id)
        {
            var work = _workPlaceService.GetById(id);
            var vm = GetModel();

            vm.BAge = work.BAge;
            vm.Description = work.Description;
            vm.Dues = work.Dues;
            vm.ExpertId = work.ExpertId;
            vm.IsinmaId = work.IsinmaId;
            vm.KimdenId = work.KimdenId;
            vm.KrediId = work.KrediId;
            vm.KurlarId = work.KurlarId;
            vm.Name = work.Name;
            vm.Price = work.Price;
            vm.Room = work.Room;
            vm.Size = work.Size;
            vm.ThumbPath = work.ThumbPath;
            vm.StatusId = work.StatusId;
            vm.IlceId = work.IlceId;
            vm.IlId = work.IlId;
            vm.SemtId = work.SemtId;
            vm.Id = work.Id;
            vm.FileDetails = work.WorkFileDetails;
            vm.SelectedProperties = work.SelectedProperties.Select(x => x.Id.ToString()).ToArray();
            vm.SelectedSecurities = work.SelectedSecurities.Select(x => x.Id.ToString()).ToArray();
            vm.SelectedSocialList = work.SelectedSocialApps.Select(x => x.Id.ToString()).ToArray();

            TempData["ThumbPath"] = work.ThumbPath;

            return View(vm);
        }


        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkPlaceViewModel work, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {
            if (ModelState.IsValid)
            {
                if (document != null)
                {
                    var imagePath = Functions.UploadImage(document);
                    work.ThumbPath = imagePath;
                }
                else
                    work.ThumbPath = TempData["ThumbPath"].ToString();

                List<FileDetailServiceModel> fileDetails = UploadFiles();

                WorkplaceServiceModel model = new WorkplaceServiceModel()
                {
                    Id = work.Id,
                    BAge = work.BAge,
                    Description = work.Description,
                    Dues = work.Dues,
                    ExpertId = work.ExpertId,
                    IsinmaId = work.IsinmaId,
                    KimdenId = work.KimdenId,
                    KrediId = work.KrediId,
                    KurlarId = work.KurlarId,
                    Name = work.Name,
                    Price = work.Price,
                    Room = work.Room,
                    Size = work.Size,
                    ThumbPath = work.ThumbPath,
                    StatusId = work.StatusId,
                    SemtId = work.SemtId,
                    WorkFileDetails = fileDetails,
                    SelectedSecurities = securitys.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedSocialApps = socials.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList(),
                    SelectedProperties = tags.Select(x => new SelectlistItem() { Id = int.Parse(x) }).ToList()
                };
                _workPlaceService.Edit(model);

                return Redirect("/Admin/AdDetails/Index");
            }

            return View(GetModel(work));
        }

        // GET: Admin/AdDetails/Delete/5
        public JsonResult Delete(int id)
        {
            try
            {
                _workPlaceService.DeleteById(id);
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
                return Json(new { Result = false, ex.Message });
            }
        }

        public JsonResult Status(int id)
        {
            try
            {
                _workPlaceService.ChangeStatus(id);
                var status = _workPlaceService.GetById(id);
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
                _workPlaceService.ChangeVitrin(id);
                var status = _workPlaceService.GetById(id);
                return Json(new { result = true, status = status.IsInVitrin });
            }
            catch (Exception)
            {
                return Json(new { result = false, status = false });
            }
        }
    }
}