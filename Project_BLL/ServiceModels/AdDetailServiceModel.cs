using System;
using System.Collections.Generic;

namespace Project_BLL.ServiceModels
{
    public class AdDetailServiceModel
    {
        public int RoomCount { get; set; }
        public int Size { get; set; }
        public decimal Dues { get; set; }
        public int FloorCount { get; set; }
        public int FlatFloor { get; set; }
        public int BAge { get; set; }
        public int BathroomCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsInVitrin { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public string ThumbPath { get; set; }
        public string Status { get; set; }
        public int? StatusId { get; set; }
        public string Kur { get; set; }
        public int? KurlarId { get; set; }
        public string Isinma { get; set; }
        public int? IsinmaId { get; set; }
        public string Kredi { get; set; }
        public int? KrediId { get; set; }
        public dynamic Expert { get; set; }
        public int? ExpertId { get; set; }
        public string Kimden { get; set; }
        public int? KimdenId { get; set; }
        public string Esya { get; set; }
        public int? EsyaId { get; set; }
        public string Site { get; set; }
        public int? SiteId { get; set; }
        public string EmlakTip { get; set; }
        public int? EmlakTipId { get; set; }
        public string Kullanim { get; set; }
        public int? KullanimId { get; set; }
        public List<FileDetailServiceModel> FileDetails { get; set; }
        public List<SelectlistItem> SelectedProperties { get; set; }
        public List<SelectlistItem> SelectedSecurities { get; set; }
        public List<SelectlistItem> SelectedSocialApps { get; set; }
    }
}