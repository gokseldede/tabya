using System.Collections.Generic;
using Project_BLL.ServiceModels;

namespace Project_UI.Areas.Admin.Models
{
    public class AdListViewModel
    {
        public List<AdDetailServiceModel> AdDetails { get; set; }
        public List<LandServiceModel> Lands { get; set; }
        public List<WorkplaceServiceModel> Workplaces { get; set; }
        public List<BuildingServiceModel> Binas { get; set; }

    }
}