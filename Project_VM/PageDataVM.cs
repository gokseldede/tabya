using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_VM
{
    public class PageDataVM
    {
    
        public List<Site> Sites { get; set; }
        public virtual Site Site { get; set; }
        public List<Project> Projects { get; set; }
        public List<AdProp> AdProps { get; set; }
        public ICollection<AdProp> AdProp { get; set; }
        public List<AdDetail> AdDetails { get; set; }
        public List<Land> Lands { get; set; }
        public List<Bina> Binas { get; set; }
        public List<Workplace> Workplaces { get; set; }
        public AdDetail AdDetail { get; set; }
        public List<Expert> Experts { get; set; }
        public List<Status> Status { get; set; }
        public List<Province> Provinces { get; set; }
        public List<Il> Iller { get; set; }
        public List<Semt> Semtler { get; set; }
        public List<FileDetail> FileDetails { get; set; }
        public List<LandFileDetail> LandFileDetails { get; set; }
        public List<WorkFileDetail> WorkFileDetails { get; set; }
        public List<BinaFileDetail> BinaFileDetails { get; set; }
        public List<Properties> Properties { get; set; }
        public ProjectFile ProjectFiles { get; set; }
       
    }
}
