using System.Collections.Generic;

namespace Project_Entity
{
   public class Properties:EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<AdDetail> AdDetailses { get; set; }
        public virtual ICollection<Bina> Binas { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }

    public class SocialApps:EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<AdDetail> AdDetailses { get; set; }
        public virtual ICollection<Bina> Binas { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
    public class Securitys:EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<AdDetail> AdDetailses { get; set; }
        public virtual ICollection<Bina> Binas { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
    public class ProjectProperties:EntityBase
    {
        public string Name { get; set; }
    }
}
