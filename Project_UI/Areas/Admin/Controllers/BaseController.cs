using System;
using System.Collections.Generic;
using System.IO;
using Project_DAL;
using System.Web.Mvc;
using Project_BLL.ServiceModels;

namespace Project_UI.Areas.Admin.Controllers
{

    public class BaseController : Controller
    {
        public ProjectContext Database;
        public BaseController()
        {
            Database = new ProjectContext();
        }

        public List<FileDetailServiceModel> UploadFiles()
        {
            List<FileDetailServiceModel> fileDetails = new List<FileDetailServiceModel>();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    FileDetailServiceModel fileDetail = new FileDetailServiceModel()
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
            return fileDetails;
        }
    }
}