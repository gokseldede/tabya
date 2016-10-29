using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class ProjectFile
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
    }
}
