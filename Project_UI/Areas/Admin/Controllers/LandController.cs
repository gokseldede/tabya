using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Entity;
using Project_UI.Areas.Admin.Models;
using System.IO;
using System.Data.Entity;
using System.Net;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class LandController : BaseController
    {
        public ActionResult Index()
        {
            List<Land> _land = Database.Land.Where(x => x.IsDelete == false).ToList();
            return View(_land);
        }

        [HttpGet]

        public ActionResult Create()
        {
            GetExpert();
            GetStatus();
            GetKredi();
            // GetEmlak();
            GetKimden();
            GetKur();
            GetImar();
            //GetProperties();
            //GetSocialApps();
            //GetSecurity();
            return View();
        }

        //Çoklu resim yükleme
        //http://www.advancesharp.com/blog/1130/image-gallery-in-asp-net-mvc-with-multiple-file-and-size

        // POST: Admin/AdDetails/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Land land, HttpPostedFileBase document)
        {
            GetExpert();
            GetStatus();
            GetKimden();
            GetKredi();
            GetKur();
            GetImar();
            //   GetEmlak();
            //GetProperties();
            //GetSocialApps();
            //GetSecurity();
            land.IsDelete = false;
            land.CreatedDate = DateTime.Now;
            land.UpdatedDate = DateTime.Now;
            land.IsActive = true;
            land.Vitrin = false;

            var imagePath = Functions.UploadImage(document);
            land.ThumbPath = imagePath;

            //foreach (var b in tags)
            //{
            //    land.properties += b + ",";
            //}
            //foreach (var c in securitys)
            //{
            //    land.securitys = string.Empty;
            //    land.securitys += c + ",";
            //}
            //foreach (var a in socials)
            //{
            //    land.socialapps += a + ",";
            //}
            if (ModelState.IsValid)
            {
                #region Çoklu resim kaydetme 
                List<LandFileDetail> fileDetails = new List<LandFileDetail>();
                for (int i = 1; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        LandFileDetail fileDetail = new LandFileDetail()
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
                land.LandFileDetails = fileDetails;
                db.Land.Add(land);
                #endregion              
                db.SaveChanges();
            }
            return Redirect("/Admin/AdDetails/Index");
        }
        // GET: Admin/AdDetails/Edit/5
        public ActionResult Edit(int ID, HttpPostedFileBase document)
        {
            GetExpert(ID);
            GetStatus(ID);
            GetKimden(ID);
            //   GetEmlak(ID);
            GetKredi(ID);
            GetImar(ID);
            GetKur(ID);
            //GetProperties();
            //GetSecurity();
            //GetSocialApps();
            GetProp();
            Land _land = Database.Land.FirstOrDefault(x => x.ID == ID);
            TempData["ImagePath"] = _land.ThumbPath;

            return View(_land);
        }

        // POST: Admin/AdDetails/Edit/5

        [HttpPost, ValidateInput(false)]

        public ActionResult Edit(Land land, HttpPostedFileBase document)
        {

            Land _land = Database.Land.FirstOrDefault(x => x.ID == land.ID);

            _land.Name = land.Name;
            _land.Description = land.Description;
            _land.ImarID = land.ImarID;
            _land.SizePrice = land.SizePrice;
            _land.AdaNo = land.AdaNo;
            _land.ParselNo = land.ParselNo;
            _land.PaftaNo = land.PaftaNo;
            _land.Kaks = land.Kaks;
            _land.Gabari = land.Gabari;
            _land.Tapu = land.Tapu;
            _land.Takas = land.Takas;
            _land.KatKarsiligi = land.KatKarsiligi;
            _land.Price = land.Price;
            _land.Location = land.Location;
            _land.Latitude = land.Latitude;
            _land.Longitude = land.Longitude;
            _land.Size = land.Size;
            // _land.EmlakTipID = land.EmlakTipID;
            _land.StatusID = land.StatusID;
            _land.KrediID = land.KrediID;
            _land.KimdenID = land.KimdenID;
            _land.ImarID = land.ImarID;
            _land.ExpertID = land.ExpertID;
            _land.KurlarID = land.KurlarID;
            //if (tags != null)
            //{
            //    _land.properties = string.Empty;
            //    foreach (var b in tags)
            //    {
            //        _land.properties += b + ",";
            //    }
            //}

            //if (securitys != null)
            //{
            //    _land.securitys = string.Empty;
            //    foreach (var c in securitys)
            //    {
            //        _land.securitys += c + ",";
            //    }
            //}
            //if (socials != null)
            //{
            //    _land.socialapps = string.Empty;
            //    foreach (var a in socials)
            //    {
            //        _land.socialapps += a + ",";
            //    }
            //}
            if (document != null)
            {
                var imagePath = Functions.UploadImage(document);
                _land.ThumbPath = imagePath;
            }
            else
            {
                _land.ThumbPath = TempData["ImagePath"].ToString();
            }
            if (ModelState.IsValid)
            {
                //New Files
                for (int i = 1; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        LandFileDetail fileDetail = new LandFileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            LandID = land.ID
                        };
                        var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        Database.Entry(fileDetail).State = EntityState.Added;
                    }
                }
                Database.Entry(_land).State = EntityState.Modified;
                _land.ID = land.ID;
                _land.UpdatedDate = DateTime.Now;
                Database.SaveChanges();
                return Redirect("/Admin/AdDetails/Index");
            }
            return View(land);
        }


        // GET: Admin/AdDetails/Delete/5
        public JsonResult Delete(int ID)
        {
            Land _land = Database.Land.Find(ID);
            _land.IsDelete = true;
            _land.DeletedDate = DateTime.Now;
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
                LandFileDetail fileDetail = db.LandFileDetails.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int) HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.LandFileDetails.Remove(fileDetail);
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
            Land _land = Database.Land.Find(ID);
            _land.IsActive = !_land.IsActive;
            Database.SaveChanges();
            return Json(_land.IsActive);
        }
        public JsonResult Vitrin(int ID)
        {
            Land _land = Database.Land.Find(ID);
            _land.Vitrin = !_land.Vitrin;
            Database.SaveChanges();
            return Json(_land.Vitrin);
        }
    }
}
