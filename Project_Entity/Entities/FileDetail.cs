using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
    public class FileDetail
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }      
        public int AdDetailID { get; set; }
        public virtual AdDetail AdDetail { get; set; }

    }

    public class BinaFileDetail
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int BinaID { get; set; }
        public virtual Bina Bina { get; set; }

    }

    public class WorkFileDetail
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int WorkplaceID { get; set; }
        public virtual Workplace Workplace { get; set; }

    }


    public class LandFileDetail
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int LandID { get; set; }
        public virtual Land Land { get; set; }

    }
}
