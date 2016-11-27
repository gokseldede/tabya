using System;
using System.Collections.Generic;

namespace Project_BLL.ServiceModels
{
    public class BuildingServiceModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int? StatusId { get; set; }
        public int Price { get; set; }
        public string Kur { get; set; }
        public int? KurlarId { get; set; }
        public string Description { get; set; }
        public int BAge { get; set; }
        public dynamic Expert { get; set; }
        public int? ExpertId { get; set; }
        public string ThumbPath { get; set; }
        public string Kimden { get; set; }
        public int? KimdenId { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsInVitrin { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public List<FileDetailServiceModel> FileDetails { get; set; }
        public string Takas { get; set; }
        public int FloorCount { get; set; }
        public int FloorFlatCount { get; set; }
        public int Size { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Semt { get; set; }
        public int? SemtId { get; set; }
        public List<SelectlistItem> SelectedProperties { get; set; }
        public List<SelectlistItem> SelectedSecurities { get; set; }
        public List<SelectlistItem> SelectedSocialApps { get; set; }
    }
}