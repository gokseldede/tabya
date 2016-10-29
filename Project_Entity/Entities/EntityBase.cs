using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class EntityBase
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            Vitrin = false;
        }

        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool Vitrin { get; set; }
    }
}
