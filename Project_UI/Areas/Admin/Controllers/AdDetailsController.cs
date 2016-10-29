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
using Project_UI.Areas.Admin.Models;
using System.Drawing;
using System.IO;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class AdDetailsController : BaseController
    {
        
        public ActionResult Index()
        {
            PageViewModel vm = new PageViewModel();
            vm.AdDetails = Database.AdDetails.Where(x => x.IsDelete == false).ToList();
            vm.Lands = Database.Land.Where(x => x.IsDelete == false).ToList();
            vm.Workplaces = Database.Workplace.Where(x => x.IsDelete == false).ToList();
            vm.Binas = Database.Bina.Where(x => x.IsDelete == false).ToList();
            return View(vm);
        }

        [HttpGet]
        // GET: Admin/AdDetails/Create
        public ActionResult Create()
        {
            GetExpert();
            GetStatus();
            GetIsınma();
            GetKredi();
            GetEmlak();
            GetKur();
            GetKimden();
            GetEsya();
            GetKullanım();
            GetSite();
            GetProperties();
            GetSocialApps();
            GetSecurity();
            return View();
        }

        //Çoklu resim yükleme
        //http://www.advancesharp.com/blog/1130/image-gallery-in-asp-net-mvc-with-multiple-file-and-size

        // POST: Admin/AdDetails/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(AdDetail adDetail, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {

            GetExpert();
            GetStatus();
            GetIsınma();
            GetKimden();
            GetKredi();
            GetEmlak();
            GetKur();
            GetEsya();
            GetSite();
            GetProperties();
            GetSocialApps();
            GetSecurity();
            GetKullanım();
            adDetail.IsDelete = false;
            adDetail.CreatedDate = DateTime.Now;
            adDetail.UpdatedDate = DateTime.Now;
            adDetail.IsActive = true;
            adDetail.Vitrin = false;

            var imagePath = Functions.UploadImage(document);
            adDetail.ThumbPath = imagePath;
          
            foreach (var b in tags)
            {
                adDetail.properties += b + ",";
            }

            foreach (var c in securitys)
            {
                adDetail.securitys = string.Empty;
                adDetail.securitys += c + ",";
            }
            foreach (var a in socials)
            {
                adDetail.socialapps += a + ",";
            }
            if (ModelState.IsValid)
            {
                #region Çoklu resim kaydetme 
                List<FileDetail> fileDetails = new List<FileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
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
                adDetail.FileDetails = fileDetails;
                db.AdDetails.Add(adDetail);
                #endregion              
                db.SaveChanges();
            }
            return Redirect("Index");
        }
        // GET: Admin/AdDetails/Edit/5
        public ActionResult Edit(int ID, HttpPostedFileBase document)
        {
            GetExpert(ID);
            GetStatus(ID);
            GetIsınma(ID);
            GetEsya(ID);
            GetKimden(ID);
            GetEmlak(ID);
            GetSite(ID);
            GetKur(ID);
            GetKullanım(ID);
            GetKredi(ID);
            GetProperties();
            GetSecurity();
            GetSocialApps();
            AdDetail _adDetail = Database.AdDetails.FirstOrDefault(x => x.ID == ID);
            TempData["ImagePath"] = _adDetail.ThumbPath;
            return View(_adDetail);
        }

        // POST: Admin/AdDetails/Edit/5

        [HttpPost, ValidateInput(false)]

        public ActionResult Edit(AdDetail adDetail, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {

            AdDetail _adDetail = Database.AdDetails.FirstOrDefault(x => x.ID == adDetail.ID);

            _adDetail.Name = adDetail.Name;
            _adDetail.Description = adDetail.Description;
            _adDetail.Price = adDetail.Price;
            _adDetail.Location = adDetail.Location;
            _adDetail.Room = adDetail.Room;
            _adDetail.Latitude = adDetail.Latitude;
            _adDetail.Longitude = adDetail.Longitude;
            _adDetail.Bath = adDetail.Bath;
            _adDetail.KullanımID = adDetail.KullanımID;
            _adDetail.EsyaID = adDetail.EsyaID;
            _adDetail.Room = adDetail.Room;
            _adDetail.Size = adDetail.Size;
            _adDetail.SiteID = adDetail.SiteID;
            _adDetail.BAge = adDetail.BAge;
            _adDetail.Floor = adDetail.Floor;
            _adDetail.FloorNumber = adDetail.FloorNumber;
            _adDetail.IsınmaID = adDetail.IsınmaID;
            _adDetail.EmlakTipID = adDetail.EmlakTipID;
            _adDetail.StatusID = adDetail.StatusID;
            _adDetail.Site = adDetail.Site;
            _adDetail.Dues = adDetail.Dues;
            _adDetail.KrediID = adDetail.KrediID;
            _adDetail.ExpertID = adDetail.ExpertID;
            _adDetail.KurlarID = adDetail.KurlarID;
            if (tags != null)
            {
                _adDetail.properties = string.Empty;
                foreach (var b in tags)
                {
                    _adDetail.properties += b + ",";
                }
            }
           
            if (securitys != null)
            {
                _adDetail.securitys = string.Empty;
                foreach (var c in securitys)
                {
                    _adDetail.securitys += c + ",";
                }
            }
            if (socials != null)
            {
                _adDetail.socialapps = string.Empty;
                foreach (var a in socials)
                {
                    _adDetail.socialapps += a + ",";
                }
            }
            if (document != null)
            {
                var imagePath = Functions.UploadImage(document);
                _adDetail.ThumbPath = imagePath;
            }
            else
            {
                _adDetail.ThumbPath = TempData["ImagePath"].ToString();
            }
            if (ModelState.IsValid)
            {
                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            AdDetailID = adDetail.ID
                        };
                        var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        Database.Entry(fileDetail).State = EntityState.Added;
                    }
                }
                Database.Entry(_adDetail).State = EntityState.Modified;
                _adDetail.ID = adDetail.ID;
                _adDetail.UpdatedDate = DateTime.Now;
                Database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adDetail);
        }


        // GET: Admin/AdDetails/Delete/5
        public JsonResult Delete(int ID)
        {
            AdDetail _adDetail = Database.AdDetails.Find(ID);
            _adDetail.IsDelete = true;
            _adDetail.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                FileDetail fileDetail = db.FileDetails.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int) HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileDetails.Remove(fileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult Status(int ID)
        {
            AdDetail _adDetail = Database.AdDetails.Find(ID);
            _adDetail.IsActive = !_adDetail.IsActive;
            Database.SaveChanges();
            return Json(_adDetail.IsActive);
        }
        public JsonResult Vitrin(int ID)
        {
            AdDetail _addetail = Database.AdDetails.Find(ID);
            _addetail.Vitrin = !_addetail.Vitrin;
            Database.SaveChanges();
            return Json(_addetail.Vitrin);
        }
    }
}
