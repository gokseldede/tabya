using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
  public  class Global:EntityBase
    {
        public string Name { get; set; }
        public int? AdminUserID { get; set; }

        public int? AdDetailID { get; set; }

        public virtual AdDetail AdDetail { get; set; }

        public virtual AdminUser AdminUser { get; set; }
    }
}
