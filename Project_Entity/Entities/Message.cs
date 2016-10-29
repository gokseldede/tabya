using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Message:EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string MessageContent { get; set; }
        public string ReplyTitle { get; set; }
        public string Reply { get; set; }

        public int? AdminUserID { get; set; }
        public virtual AdminUser AdminUser { get; set; }
    }
}
