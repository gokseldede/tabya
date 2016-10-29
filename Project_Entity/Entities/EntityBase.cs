using System;

namespace Project_Entity
{
    public class EntityBase
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool Vitrin { get; set; }
    }
}
