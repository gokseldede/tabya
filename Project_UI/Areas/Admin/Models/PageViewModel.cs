using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_UI.Areas.Admin.Models
{
    public class PageViewModel
    {
        public virtual AdDetail AdDetail { get; set; }
        public virtual Land Land { get; set; }
        public List<AdDetail> AdDetails { get; set; }
        public List<Land> Lands { get; set; }
        public virtual Workplace Workplace { get; set; }
        public virtual Bina Bina { get; set; }
        public List<Workplace> Workplaces { get; set; }
        public List<Bina> Binas { get; set; }


        public List<Properties> Properties { get; set; }
        public Properties Properti { get; set; }        
        public List<Properties> Rules { get; set; }
        public List<Properties> SelectedRules { get; set; }
        public List<string> PostedRuleIDs { get; set; }
    }
}