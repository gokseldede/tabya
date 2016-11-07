﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Project_BLL.ServiceModels;

namespace Project_UI.Areas.Admin.Models
{
    public class BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsInVitrin { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }

        public string ThumbPath { get; set; }
        public int? StatusId { get; set; }
        public int? KurlarId { get; set; }
        public int? IsinmaId { get; set; }
        public int? KrediId { get; set; }
        public int? ExpertId { get; set; }
        public int? KimdenId { get; set; }

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
        public List<FileDetailServiceModel> FileDetails { get; set; }

        public int? ImarId { get; set; }
        public List<SelectListItem> ImarStatusList { get; set; }

        public int? EsyaId { get; set; }
        public List<SelectListItem> EsyaList { get; set; }

        public int? SiteId { get; set; }
        public List<SelectListItem> SiteList { get; set; }

        public int? EmlakTipId { get; set; }
        public List<SelectListItem> EmlakTipList { get; set; }

        public int? KullanimId { get; set; }
        public List<SelectListItem> KullanimList { get; set; }
    }
    public class WorkPlaceViewModel : BaseViewModel
    {
        public string Room { get; set; }
        public int Size { get; set; }
        public int IlceId { get; set; }
        public int BAge { get; set; }
        public int Dues { get; set; }
    }
}