using System;
using System.Collections.Generic;

namespace Project_BLL.ServiceModels
{
    public class WorkplaceServiceModel
    {
        public string Name { get; set; }
        public int? StatusId { get; set; }
        public int Price { get; set; }
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
        public List<FileDetailServiceModel> WorkFileDetails { get; set; }
    }
}