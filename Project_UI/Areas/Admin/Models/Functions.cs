using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Models
{
    public class Functions
    {
        public static string UploadImage(HttpPostedFileBase document)
        {
            if (document != null)
            {
                var fileName = document.FileName;
                var Path = HttpContext.Current.Server.MapPath("/Areas/Admin/Content/Image/" + fileName);

                document.SaveAs(Path);
                return "/Areas/Admin/Content/Image/" + fileName;
            }
            else
                return null;
        }

        public static string UploadVideo(HttpPostedFileBase video)
        {
            if (video != null)
            {
                var fileName = video.FileName;
                var Path = HttpContext.Current.Server.MapPath("/Areas/Admin/Content/Videos/" + fileName);

                video.SaveAs(Path);
                return "/Areas/Admin/Content/Videos/" + fileName;
            }
            else
                return null;
        }
    }
}
