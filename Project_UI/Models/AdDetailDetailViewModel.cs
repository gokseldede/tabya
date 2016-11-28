using System;
using System.Collections.Generic;
using Project_BLL.ServiceModels;

namespace Project_UI.Models
{
    public class AdDetailDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
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

        public string EmlakTip { get; set; }
        public string Takas { get; set; }
        public dynamic Expert { get; set; }
        public string Kimden { get; set; }
        public string Status { get; set; }
        public string Isinma { get; set; }
        public string KrediDurumu { get; set; }
        public string Kur { get; set; }

        public string[] SelectedProperties { get; set; }
        public string[] SelectedSocialList { get; set; }
        public string[] SelectedSecurities { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Semt { get; set; }
        public List<FileDetailServiceModel> FileDetails { get; set; }
        public string ImarStatus { get; set; }
        public string EsyaStatus { get; set; }
        public string SiteStatus { get; set; }
        public string KullanimStatus { get; set; }
        public string RoomCount { get; set; }
        public int Size { get; set; }
        public decimal Dues { get; set; }
        public int FloorCount { get; set; }
        public int FlatFloor { get; set; }
        public int BAge { get; set; }
        public int BathroomCount { get; set; }
        public int SizePrice { get; set; }
        public int AdaNo { get; set; }
        public string Gabari { get; set; }
        public string Imar { get; set; }
        public string Kaks { get; set; }
        public string KatKarsiligi { get; set; }
        public int ParselNo { get; set; }
        public int PaftaNo { get; set; }
        public string Tapu { get; set; }
        public int FloorFlatCount { get; set; }
    }
}