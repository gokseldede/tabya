using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_BLL.ServiceModels;

namespace Project_UI.Models
{
    public class ProjectDetailViewModel
    {
        public string PriceList { get; set; }
        public string[] SelectedProperties { get; set; }
        public string[] SelectedSecurities { get; set; }
        public string[] SelectedSocialList { get; set; }
        public string Description { get; set; }
        public dynamic Expert { get; set; }
        public string Video { get; set; }
        public string Name { get; set; }
        public List<FileDetailServiceModel> ProjectFiles { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ProjectLocation { get; set; }
        public string ProjectFirm { get; set; }
        public int ProjectArea { get; set; }
        public int FlatCount { get; set; }
    }
}