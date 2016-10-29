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
using System.IO;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class ProjectsController : BaseController
    {
      

        // GET: Admin/Projects
        public ActionResult Index()
        {
            List<Project> _project = Database.Projects.Where(x => x.IsDelete == false).ToList();
            return View(_project);
        }


        // GET: Admin/Projects/Create
        public ActionResult Create()
        {
            GetExpert();
            GetProperties();
            GetSecurity();
            GetSocialApps();
            return View();
        }

        // POST: Admin/Projects/Create

        [HttpPost, ValidateInput(false)]

        public ActionResult Create(Project project, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document, HttpPostedFileBase pricelist)
        {

            GetExpert();
            GetProperties();
            GetSecurity();
            GetSocialApps();
            project.IsDelete = false;
            project.CreatedDate = DateTime.Now;
            project.UpdatedDate = DateTime.Now;
            project.IsActive = true;


            var imagePath = Functions.UploadImage(document);

            project.ImagePath = imagePath;
            var price = Functions.UploadImage(pricelist);
            project.PriceList = price;

            foreach (var b in tags)
            {
                project.properties += b + ",";
            }
            foreach (var c in securitys)
            {
                project.securitys += c + ",";
            }
            foreach (var a in socials)
            {
                project.socialapps += a + ",";
            }

            if (ModelState.IsValid)
            {
                List<ProjectFile> fileDetails = new List<ProjectFile>();
                for (int i = 2; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ProjectFile fileDetail = new ProjectFile()
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
                project.ProjectFiles = fileDetails;
                db.Projects.Add(project);
                db.SaveChanges();
            }


            return Redirect("Index");
        }

        // GET: Admin/Projects/Edit/5
        public ActionResult Edit(int ID, HttpPostedFileBase document)
        {
            GetExpert(ID);
            GetProperties();
            GetSecurity();
            GetSocialApps();
            Project _project = Database.Projects.FirstOrDefault(x => x.ID == ID);
            TempData["ImagePath"] = _project.ImagePath;
            return View(_project);

        }

        // POST: Admin/Projects/Edit/5

        [HttpPost, ValidateInput(false)]

        public ActionResult Edit(Project project, string[] tags, string[] socials, string[] securitys, HttpPostedFileBase document, HttpPostedFileBase pricelist)
        {

            Project _project = Database.Projects.FirstOrDefault(x => x.ID == project.ID);

            if (document != null)
            {
                var imagePath = Functions.UploadImage(document);
                _project.ImagePath = imagePath;
            }
            else
            {
                _project.ImagePath = TempData["ImagePath"].ToString();
            }
            if (pricelist != null)
            {
                var price = Functions.UploadImage(pricelist);
                _project.PriceList = price;
            }
            else
            {
                _project.PriceList = TempData["PriceList"].ToString();
            }

            _project.Name = project.Name;
            _project.SubName = project.SubName;
            _project.SSubName = project.SSubName;
            _project.Description = project.Description;
            _project.ProjectA = project.ProjectA;
            _project.HouseN = project.HouseN;
            _project.DeliveryDate = project.DeliveryDate;
            _project.ExpertID = project.ExpertID;
            _project.Video = project.Video;
            if (tags != null)
            {
                _project.properties = string.Empty;
                foreach (var b in tags)
                {
                    _project.properties += b + ",";
                }
            }
            if (securitys != null)
            {
                _project.securitys = string.Empty;
                foreach (var c in securitys)
                {
                    _project.securitys += c + ",";
                }
            }
            if (socials != null)
            {
                _project.socialapps = string.Empty;
                foreach (var a in socials)
                {
                    _project.socialapps += a + ",";
                }
            }
            if (ModelState.IsValid)
            {
                for (int i = 2; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ProjectFile fileDetail = new ProjectFile()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            ProjectID = project.ID
                        };
                        var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Image/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        Database.Entry(fileDetail).State = EntityState.Added;
                    }
                }
                Database.Entry(_project).State = EntityState.Modified;
                _project.ID = project.ID;
                _project.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        // GET: Admin/Projects/Delete/5
        public JsonResult Delete(int ID)
        {
            Project _project = Database.Projects.Find(ID);
            _project.IsDelete = true;
            _project.DeletedDate = DateTime.Now;
            Database.SaveChanges();
            return Json(" ");

        }

        //Galeri resim silme
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
            Project _project = Database.Projects.Find(ID);
            _project.IsActive = !_project.IsActive;
            Database.SaveChanges();
            return Json(_project.IsActive);
        }
    }
}
