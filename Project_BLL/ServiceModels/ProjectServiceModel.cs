using System;
using System.Collections.Generic;

namespace Project_BLL.ViewModels
{
    public class ProjectServiceModel
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
        public List<FileDetailServiceModel> ProjectFileDetails { get; set; }
    }
}