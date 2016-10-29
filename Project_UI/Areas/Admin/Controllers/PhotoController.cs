using PagedList;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    public class PhotoController : BaseController
    {
        void GetIlan()
        {
            ViewData["Ilan"] = Database.AdDetails.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
            });
        }
        void GetIlan(int ID)
        {
            ViewData["Ilan"] = Database.AdDetails.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }


        // GET: Admin/Photo
        public ActionResult Index()
        {
            return View();
        }

        public Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int) (tempval * imageSize.Width), (int) (tempval * imageSize.Height));
            }
            else
                finalSize = imageSize; // image is already small size

            return finalSize;
        }
        private void SaveToFolder(Image img, string fileName, string extension, Size newSize, string pathToSave)
        {
            // Get new resolution
            Size imgSize = NewImageSize(img.Size, newSize);
            using (System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
            {
                newImg.Save(Server.MapPath(pathToSave), img.RawFormat);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetIlan();
            var photo = new FileDetail();
            return View(photo);
        }

        [HttpPost]
        public ActionResult Create(FileDetail photo, IEnumerable<HttpPostedFileBase> files)
        {
            GetIlan();
            //if (!ModelState.IsValid)
            //    return View(photo);
            //if (files.Count() == 0 || files.FirstOrDefault() == null)
            //{
            //    ViewBag.error = "Please choose a file";
            //    return View(photo);
            //}

            //var model = new FileDetail();
            //foreach (var file in files)
            //{
            //    if (file.ContentLength == 0) continue;

            // model.AdDetailID = photo.AdDetailID;
            // //   model.Description = photo.Description;
            //    var fileName = Guid.NewGuid().ToString();
            //    var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

            //    using (var img = System.Drawing.Image.FromStream(file.InputStream))
            //    {
            //        model.ThumbPath = String.Format("/Areas/Admin/Content/thumbs/{0}{1}", fileName, extension);
            //        model.ImagePath = String.Format("/Areas/Admin/Content/Image/{0}{1}", fileName, extension);

            //        // Save thumbnail size image, 100 x 100
            //        SaveToFolder(img, fileName, extension, new Size(100, 100), model.ThumbPath);

            //        // Save large size image, 800 x 800
            //        SaveToFolder(img, fileName, extension, new Size(600, 600), model.ImagePath);
            //    }

            //    // Save record to database
            //    model.CreatedOn = DateTime.Now;
            //    db.Photos.Add(model);
            //    db.SaveChanges();


            //}

            return Redirect("/Admin/Home/Index");
        }


    }
}