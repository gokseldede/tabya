using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using Project_UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class BuildingController : BaseController
    {
        // GET: Admin/Building
        public ActionResult Index()
        {
            List<Bina> _bina = Database.Bina.Where(x => x.IsDelete == false).ToList();
            return View(_bina);
        }

        [HttpGet]

        public ActionResult Create()
        {
            GetEmlak();
            GetExpert();
            GetStatus();
            GetKur();
            GetKimden();
            GetProperties();
            GetSocialApps();
            GetSecurity();
            return View();
        }

        //Çoklu resim yükleme
        //http://www.advancesharp.com/blog/1130/image-gallery-in-asp-net-mvc-with-multiple-file-and-size

        // POST: Admin/AdDetails/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Bina bina, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {
            GetEmlak();
            GetExpert();
            GetStatus();
            GetKimden();
            GetKur();
            GetProperties();
            GetSocialApps();
            GetSecurity();
            bina.IsDelete = false;
            bina.CreatedDate = DateTime.Now;
            bina.UpdatedDate = DateTime.Now;
            bina.IsActive = true;
            bina.Vitrin = false;

            var imagePath = Functions.UploadImage(document);
            bina.ThumbPath = imagePath;
            foreach (var b in tags)
            {
                bina.properties += b + ",";
            }

            foreach (var c in securitys)
            {
                bina.securitys = string.Empty;
                bina.securitys += c + ",";
            }
            foreach (var a in socials)
            {
                bina.socialapps += a + ",";
            }
            if (ModelState.IsValid)
            {
                #region Çoklu resim kaydetme 
                List<BinaFileDetail> fileDetails = new List<BinaFileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        BinaFileDetail fileDetail = new BinaFileDetail()
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
                bina.BinaFileDetails = fileDetails;
                db.Bina.Add(bina);
                #endregion              
                db.SaveChanges();
            }
            return Redirect("/Admin/AdDetails/Index");
        }

        public ActionResult Edit(int ID, HttpPostedFileBase document)
        {
            GetEmlak(ID);
            GetExpert(ID);
            GetStatus(ID);
            GetKimden(ID);
            GetKur(ID);
            GetProperties();
            GetSecurity();
            GetSocialApps();
            GetProp();
            Bina _bina = Database.Bina.FirstOrDefault(x => x.ID == ID);
            TempData["ImagePath"] = _bina.ThumbPath;
            return View(_bina);
        }

        // POST: Admin/AdDetails/Edit/5

        [HttpPost, ValidateInput(false)]

        public ActionResult Edit(Bina bina, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {

            Bina _bina = Database.Bina.FirstOrDefault(x => x.ID == bina.ID);

            _bina.Name = bina.Name;
            _bina.Description = bina.Description;
            _bina.Takas = bina.Takas;
            _bina.Price = bina.Price;
            _bina.Location = bina.Location;
            _bina.Latitude = bina.Latitude;
            _bina.Longitude = bina.Longitude;
            _bina.Size = bina.Size;
            _bina.EmlakTipID = bina.EmlakTipID;
            _bina.StatusID = bina.StatusID;
            _bina.KimdenID = bina.KimdenID;
            _bina.ExpertID = bina.ExpertID;
            _bina.IsınmaID = bina.IsınmaID;
            _bina.Floor = bina.Floor;
            _bina.FloorRoom = bina.FloorRoom;
            _bina.BAge = bina.BAge;
            _bina.KurlarID = bina.KurlarID;
            if (tags != null)
            {
                _bina.properties = string.Empty;
                foreach (var b in tags)
                {
                    _bina.properties += b + ",";
                }
            }
            if (securitys != null)
            {
                _bina.securitys = string.Empty;
                foreach (var c in securitys)
                {
                    _bina.securitys += c + ",";
                }
            }
            if (socials != null)
            {
                _bina.socialapps = string.Empty;
                foreach (var a in socials)
                {
                    _bina.socialapps += a + ",";
                }
            }

            if (document != null)
            {
                var imagePath = Functions.UploadImage(document);
                _bina.ThumbPath = imagePath;
            }
            else
            {
                _bina.ThumbPath = TempData["ImagePath"].ToString();
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
                        BinaFileDetail fileDetail = new BinaFileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            BinaID = bina.ID
                        };
                        var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        Database.Entry(fileDetail).State = EntityState.Added;
                    }
                }
                Database.Entry(_bina).State = EntityState.Modified;
                _bina.ID = bina.ID;
                _bina.UpdatedDate = DateTime.Now;
                Database.SaveChanges();
                return Redirect("/Admin/AdDetails/Index");
            }
            return View(bina);
        }



        public JsonResult Delete(int ID)
        {
            Bina _bina = Database.Bina.Find(ID);
            _bina.IsDelete = true;
            _bina.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                BinaFileDetail fileDetail = db.BinaFileDetail.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.BinaFileDetail.Remove(fileDetail);
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
            Bina _bina = Database.Bina.Find(ID);
            _bina.IsActive = !_bina.IsActive;
            Database.SaveChanges();
            return Json(_bina.IsActive);
        }
        public JsonResult Vitrin(int ID)
        {
            Bina _bina = Database.Bina.Find(ID);
            _bina.Vitrin = !_bina.Vitrin;
            Database.SaveChanges();
            return Json(_bina.Vitrin);
        }
    }
}