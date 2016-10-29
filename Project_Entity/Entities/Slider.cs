using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Slider:EntityBase
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public string SubText { get; set; }
        public int? AdminUserID { get; set; }

        public virtual AdminUser AdminUser { get; set; }

    }
}
