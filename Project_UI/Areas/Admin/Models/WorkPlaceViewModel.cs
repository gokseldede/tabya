using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_BLL.ViewModels;

namespace Project_UI.Areas.Admin.Models
{
    public class WorkPlaceViewModel
    {
        public string Name { get; set; }
        public int? StatusId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int? KurlarId { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }
        public int Size { get; set; }
        public int IlceId { get; set; }
        public int? IsinmaId { get; set; }
        public int? KrediId { get; set; }
        public int BAge { get; set; }
        public int? ExpertId { get; set; }
        public string ThumbPath { get; set; }
        public int Dues { get; set; }
        public int? KimdenId { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsInVitrin { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public List<SelectListItem> ExpertList { get; set; }
        public List<SelectListItem> KimdenList { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> IsinmaList { get; set; }
        public List<SelectListItem> KrediList { get; set; }
        public List<SelectListItem> KurlarList { get; set; }
        public List<SelectListItem> PropertiesList { get; set; }
        public List<SelectListItem> SocialList { get; set; }
        public List<SelectListItem> SecuritiesList { get; set; }
        public List<SelectListItem> IlList { get; set; }
        public List<FileDetailServiceModel> WorkFileDetails { get; set; }
    }
}