using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
    public class Il:EntityBase
    {
        public string Ad { get; set; }

        public virtual ICollection<Ilce> Ilceler { get; set; }
      
    }

    public class Ilce:EntityBase
    {
 
        public int IlID { get; set; }
        public string Ad { get; set; }

        public virtual Il Il { get; set; }
    }
    public class Semt : EntityBase
    {

        public int IlceID { get; set; }
        public string Ad { get; set; }
        public virtual Ilce Ilce { get; set; }
    }

  
  
}