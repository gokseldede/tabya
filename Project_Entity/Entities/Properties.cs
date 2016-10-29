using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Properties:EntityBase
    {
        public string Name { get; set; }
    }

    public class SocialApps:EntityBase
    {
        public string Name { get; set; }
    }
    public class Securitys:EntityBase
    {
        public string Name { get; set; }
    }
    public class ProjectProperties:EntityBase
    {
        public string Name { get; set; }
    }
}
