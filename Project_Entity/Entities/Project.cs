using System;
using System.Collections.Generic;

namespace Project_Entity
{
  public  class Project:EntityBase
    {
      
        public string Name { get; set; }
        public string SubName { get; set; }
        public string SSubName { get; set; }
        public string Description { get; set; }
        public string ProjectA { get; set; }
        public string HouseN { get; set; }
        public string ImagePath { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Video { get; set; }
        public string PriceList { get; set; }
        public string properties { get; set; }
        public string securitys { get; set; }
        public string socialapps { get; set; }
        public virtual List<ProjectFile> ProjectFiles { get; set; }
        public int? ExpertID { get; set; }
        public int? AdminUserID { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual Expert Expert { get; set; }
        

    }


}
