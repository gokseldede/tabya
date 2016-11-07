using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Isinma:EntityBase
    {
        public string Name { get; set; }
        public int? AdminUserID { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual List<AdDetail> AdDetail { get; set; }
        public virtual List<Workplace> Workplace { get; set; }
    }

    public class Kredi:EntityBase
    {
        public string Name { get; set; }
        public int? AdminUserID { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual List<AdDetail> AdDetail { get; set; }
        public virtual List<Workplace> Workplace { get; set; }
        public virtual List<Land> Land { get; set; }
    }

    public class Kullanim:EntityBase
    {
        public string Name { get; set; }
        public int? AdminUserID { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual List<AdDetail> AdDetail { get; set; }
    }

    public class Esya:EntityBase
    {
        public string Name { get; set; }
        public int? AdminUserID { get; set; }
    }
    public class EmlakTip:EntityBase
    {
        public string Name { get; set; }
        public int? AdminUserID { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual List<AdDetail> AdDetail { get; set; }
        public virtual List<Bina> Bina { get; set; }
        public virtual List<Workplace> Workplace { get; set; }
      //  public virtual List<Land> Land { get; set; }
    }
}
