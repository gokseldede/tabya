using System.Collections.Generic;
using Project_BLL.ServiceModels;
namespace Project_UI.Models
{
    public class QueryViewModel
    {
        public string Query { get; set; }
        public string Order { get; set; }
        public List<NewAdvertisement> List { get; set; }
    }
}