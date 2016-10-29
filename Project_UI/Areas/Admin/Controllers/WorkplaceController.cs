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
    public class WorkplaceController : BaseController
    {
        public ActionResult Index()
        {
            List<Workplace> _work = Database.Workplace.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            return View(_work);
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
            GetKimden();
            GetKur();
            GetProperties();
            GetSocialApps();
            GetSecurity();
            return View();
        }

        //Çoklu resim yükleme
        //http://www.advancesharp.com/blog/1130/image-gallery-in-asp-net-mvc-with-multiple-file-and-size

        // POST: Admin/AdDetails/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Workplace work, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {
            GetExpert();
            GetStatus();
            GetIsınma();
            GetKimden();
            GetKredi();
            GetEmlak();
            GetProperties();
            GetSocialApps();
            GetSecurity();
            work.IsDelete = false;
            work.CreatedDate = DateTime.Now;
            work.UpdatedDate = DateTime.Now;
            work.IsActive = true;
            work.Vitrin = false;
            var imagePath = Functions.UploadImage(document);
            work.ThumbPath = imagePath;
            foreach (var b in tags)
            {
                work.properties += b + ",";
            }
            foreach (var c in securitys)
            {
                work.securitys = string.Empty;
                work.securitys += c + ",";
            }
            foreach (var a in socials)
            {
                work.socialapps += a + ",";
            }
            if (ModelState.IsValid)
            {
                #region Çoklu resim kaydetme 
                List<WorkFileDetail> fileDetails = new List<WorkFileDetail>();
                for (int i = 1; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        WorkFileDetail fileDetail = new WorkFileDetail()
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
                work.WorkFileDetails = fileDetails;
                db.Workplace.Add(work);
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
            GetIsınma(ID);
            GetKimden(ID);
            GetEmlak(ID);
            GetKredi(ID);
            GetKur(ID);
            GetProperties();
            GetSecurity();
            GetSocialApps();
            GetProp();
            Workplace _work = Database.Workplace.FirstOrDefault(x => x.ID == ID);
            TempData["ImagePath"] = _work.ThumbPath;
            return View(_work);
        }

        // POST: Admin/AdDetails/Edit/5

        [HttpPost, ValidateInput(false)]

        public ActionResult Edit(Workplace work, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document)
        {

            Workplace _work = Database.Workplace.FirstOrDefault(x => x.ID == work.ID);

            _work.Name = work.Name;
            _work.Description = work.Description;
            _work.Price = work.Price;
            _work.Location = work.Location;
            _work.Latitude = work.Latitude;
            _work.Longitude = work.Longitude;
            _work.Size = work.Size;
            _work.Room = work.Room;
            _work.BAge = work.BAge;
            _work.IsınmaID = work.IsınmaID;
            _work.EmlakTipID = work.EmlakTipID;
            _work.StatusID = work.StatusID;
            _work.Dues = work.Dues;
            _work.Takas = work.Takas;
            _work.KrediID = work.KrediID;
            _work.KurlarID = work.KurlarID;
            if (tags != null)
            {
                _work.properties = string.Empty;
                foreach (var b in tags)
                {
                    _work.properties += b + ",";
                }
            }

            if (securitys != null)
            {
                _work.securitys = string.Empty;
                foreach (var c in securitys)
                {
                    _work.securitys += c + ",";
                }
            }
            if (socials != null)
            {
                _work.socialapps = string.Empty;
                foreach (var a in socials)
                {
                    _work.socialapps += a + ",";
                }
            }
            if (document != null)
            {
                var imagePath = Functions.UploadImage(document);
                _work.ThumbPath = imagePath;
            }
            else
            {
                _work.ThumbPath = TempData["ImagePath"].ToString();
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
                        WorkFileDetail fileDetail = new WorkFileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            WorkplaceID = _work.ID
                        };
                        var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        Database.Entry(fileDetail).State = EntityState.Added;
                    }
                }
                Database.Entry(_work).State = EntityState.Modified;
                _work.ID = work.ID;
                _work.UpdatedDate = DateTime.Now;
                Database.SaveChanges();
                return Redirect("/Admin/AdDetails/Index");
            }
            return View(work);
        }


        // GET: Admin/AdDetails/Delete/5
        public JsonResult Delete(int ID)
        {
            Workplace _work = Database.Workplace.Find(ID);
            _work.IsDelete = true;
            _work.DeletedDate = DateTime.Now;
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
                WorkFileDetail fileDetail = db.WorkFileDetails.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.WorkFileDetails.Remove(fileDetail);
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
            Workplace _work = Database.Workplace.Find(ID);
            _work.IsActive = !_work.IsActive;
            Database.SaveChanges();
            return Json(_work.IsActive);
        }
        public JsonResult Vitrin(int ID)
        {
            Workplace _work = Database.Workplace.Find(ID);
            _work.Vitrin = !_work.Vitrin;
            Database.SaveChanges();
            return Json(_work.Vitrin);
        }
    }
}