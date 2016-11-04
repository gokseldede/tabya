using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_BLL.ViewModels;

namespace Project_UI.Areas.Admin.Models
{
    public class ProjectViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int IlceId { get; set; }
        public int? ExpertId { get; set; }
        public string ThumbPath { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsInVitrin { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string ProjectFirm { get; set; }
        public decimal ProjectArea { get; set; }
        public int FlatCount { get; set; }
        public DateTime ProjectDeliveryDate { get; set; }
        public string ProjectPromotionVideo { get; set; }
        public string ProjectLocation { get; set; }
        public string PriceList { get; set; }
        public List<SelectListItem> ExpertList { get; set; }
        public List<SelectListItem> PropertiesList { get; set; }
        public List<SelectListItem> SocialList { get; set; }
        public List<SelectListItem> SecuritiesList { get; set; }
        public List<FileDetailServiceModel> ProjectFiles { get; set; }
    }
}