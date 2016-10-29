using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class AdProp
    {
        public int ID { get; set; }
        public int AdDetailID { get; set; }
        public virtual AdDetail AdDetail { get; set; }
        public int PropertiesID { get; set; }
        public virtual Properties Properties { get; set; }
    }
}
