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
        public int? StatusId { get; set; }
        public int? KurlarId { get; set; }
        public int? IsinmaId { get; set; }
        public int? KrediId { get; set; }
        public int? ExpertId { get; set; }
        public int? KimdenId { get; set; }
        public int? EsyaId { get; set; }
        public int? SiteId { get; set; }
        public int? EmlakTipId { get; set; }
        public int? KullanimId { get; set; }
        public List<FileDetailServiceModel> FileDetails { get; set; }
    }
}