using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class ProjectFile: BaseFileDetail
    {
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
    }
}
