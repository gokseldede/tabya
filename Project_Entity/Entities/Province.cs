using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
  public  class Province:EntityBase
    {
        public string Name { get; set; }

        public int? AdminUserID { get; set; }

        public virtual AdminUser AdminUser { get; set; }
        
  
    }
}
