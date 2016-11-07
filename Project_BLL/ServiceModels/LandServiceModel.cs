using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BLL.ServiceModels
{
    public class LandServiceModel
    {
        public int Size { get; set; }
        public int PriceForM2 { get; set; }
        public int AdaNo { get; set; }
        public int ParselNo { get; set; }
        public int PaftaNo { get; set; }
        public string Emsal { get; set; }
        public string Gabari { get; set; }
        public string TapuDurumu { get; set; }
        public string KatKarsiligi { get; set; }
        public string Takas { get; set; }
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
        public int? KrediId { get; set; }
        public int? ExpertId { get; set; }
        public int? KimdenId { get; set; }
        public int? ImarId { get; set; }
        public List<FileDetailServiceModel> FileDetails { get; set; }
    }
}
