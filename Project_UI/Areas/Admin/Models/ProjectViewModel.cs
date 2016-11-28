using System;

namespace Project_UI.Areas.Admin.Models
{
    public class ProjectViewModel : BaseViewModel
    {
        public string ProjectFirm { get; set; }
        public int ProjectArea { get; set; }
        public int FlatCount { get; set; }
        public DateTime ProjectDeliveryDate { get; set; }
        public string ProjectPromotionVideo { get; set; }
        public string ProjectLocation { get; set; }
        public string PriceList { get; set; }
    }
}