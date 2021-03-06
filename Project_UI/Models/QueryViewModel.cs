﻿using System.Collections.Generic;
using Project_BLL.ServiceModels;
namespace Project_UI.Models
{
    public class QueryViewModel
    {
        public string Query { get; set; }
        public string Order { get; set; }
        public int IlId { get; set; }
        public int IlceId { get; set; }
        public string Boyut { get; set; }
        public string AdType { get; set; }
        public string Oda { get; set; }
        public List<NewAdvertisement> List { get; set; }
    }
}