using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
    public class BaseFileDetail
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
    }
    public class FileDetail : BaseFileDetail
    {
        public int AdDetailID { get; set; }
        public virtual AdDetail AdDetail { get; set; }

    }

    public class BinaFileDetail : BaseFileDetail
    {
        public int BinaID { get; set; }
        public virtual Bina Bina { get; set; }

    }

    public class WorkFileDetail : BaseFileDetail
    {
        public int WorkplaceID { get; set; }
        public virtual Workplace Workplace { get; set; }

    }


    public class LandFileDetail : BaseFileDetail
    {
        public int LandID { get; set; }
        public virtual Land Land { get; set; }

    }
}
