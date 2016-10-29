using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
    public class AdDetail : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Room { get; set; }
        public string Size { get; set; }
        public int BAge { get; set; }
        public int Floor { get; set; }
        public int Bath { get; set; }
        public int? SiteID { get; set; }
        public virtual Site Site { get; set; }
        public string Dues { get; set; }
        public string FloorNumber { get; set; }
        public string ThumbPath { get; set; }

        public string properties { get; set; }

        public string securitys { get; set; }
        public string socialapps { get; set; }
        public int? ExpertID { get; set; }
        public int? StatusID { get; set; }

        public int? AdminUserID { get; set; }
        public int? IsınmaID { get; set; }
        public int? KrediID { get; set; }
        public int? EmlakTipID { get; set; }
        public virtual EmlakTip EmlakTip { get; set; }
        public int? KimdenID { get; set; }
        public virtual Kimden Kimden { get; set; }
        public int? KullanımID { get; set; }
        public virtual Kullanım Kullanım { get; set; }
        public virtual List<FileDetail> FileDetails { get; set; }

        public int? EsyaID { get; set; }
        public virtual Esya Esya { get; set; }
        public virtual Isinma Isınma { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual Kredi Kredi { get; set; }
        public virtual Expert Expert { get; set; }

        public int? KurlarID { get; set; }
        public virtual Kurlar Kurlar { get; set; }
        public virtual List<Global> Global { get; set; }
        public virtual Status Status { get; set; }

        public virtual Il Il { get; set; }
        public virtual Ilce Ilce { get; set; }
        public virtual Semt Semt { get; set; }
    }
    public class Site : EntityBase
    {
        public string Name { get; set; }
        public virtual List<AdDetail> AdDetail { get; set; }
        public virtual List<Workplace> Workplace { get; set; }
        public virtual List<Land> Land { get; set; }
    }
    public class Kurlar : EntityBase
    {
        public string Name { get; set; }
        public virtual List<AdDetail> AdDetail { get; set; }
        public virtual List<Workplace> Workplace { get; set; }
        public virtual List<Land> Land { get; set; }
        public virtual List<Bina> Bina { get; set; }
    }
    public class Kimden : EntityBase
    {
        public string Name { get; set; }
        public virtual List<AdDetail> AdDetail { get; set; }
        public virtual List<Workplace> Workplace { get; set; }
        public virtual List<Land> Land { get; set; }
        public virtual List<Bina> Bina { get; set; }
    }

    public class Workplace : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Size { get; set; }
        public string Room { get; set; }
        public int BAge { get; set; }
        public string Dues { get; set; }
        public string ThumbPath { get; set; }
        public string properties { get; set; }
        public string securitys { get; set; }
        public string socialapps { get; set; }
        public int? StatusID { get; set; }
        public int? AdminUserID { get; set; }
        public int? IsınmaID { get; set; }
        public int? KrediID { get; set; }
        public int? EmlakTipID { get; set; }
        public virtual EmlakTip EmlakTip { get; set; }
        public int? KimdenID { get; set; }
        public virtual Kimden Kimden { get; set; }
        public string Takas { get; set; }
        public virtual List<WorkFileDetail> WorkFileDetails { get; set; }
        public virtual Isinma Isınma { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual Kredi Kredi { get; set; }
        public int? ExpertID { get; set; }
        public virtual Expert Expert { get; set; }
        public virtual Status Status { get; set; }
        public int? KurlarID { get; set; }
        public virtual Kurlar Kurlar { get; set; }
    }

    public class Imar : EntityBase
    {
        public string Name { get; set; }
        public List<Land> Land { get; set; }
    }

    public class Land : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public int? EmlakTipID { get; set; }
        //public virtual EmlakTip EmlakTip { get; set; }
        public int? ExpertID { get; set; }
        public virtual Expert Expert { get; set; }
        public int? ImarID { get; set; }
        public virtual Imar Imar { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
        public string SizePrice { get; set; }
        public int AdaNo { get; set; }
        public int ParselNo { get; set; }
        public int PaftaNo { get; set; }
        public string Kaks { get; set; }
        public string Gabari { get; set; }
        public string Tapu { get; set; }
        public int? KrediID { get; set; }
        public virtual Kredi Kredi { get; set; }
        public string Takas { get; set; }
        public string KatKarsiligi { get; set; }
        //public string properties { get; set; }
        //public string securitys { get; set; }
        //public string socialapps { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ThumbPath { get; set; }
        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }
        public int? KimdenID { get; set; }
        public virtual Kimden Kimden { get; set; }
        public virtual List<LandFileDetail> LandFileDetails { get; set; }
        public int? KurlarID { get; set; }
        public virtual Kurlar Kurlar { get; set; }
    }

    public class Bina : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int BAge { get; set; }
        public int? ExpertID { get; set; }
        public virtual Expert Expert { get; set; }
        public int? EmlakTipID { get; set; }
        public virtual EmlakTip EmlakTip { get; set; }
        public int? StatusID { get; set; }
        public virtual Status Status { get; set; }
        public string Size { get; set; }
        public int? KimdenID { get; set; }
        public virtual Kimden Kimden { get; set; }
        public int? IsınmaID { get; set; }
        public virtual Isinma Isınma { get; set; }
        public int Floor { get; set; }
        public int FloorRoom { get; set; }
        public string Takas { get; set; }
        public string ThumbPath { get; set; }
        public string properties { get; set; }
        public string socialapps { get; set; }
        public string securitys { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual List<BinaFileDetail> BinaFileDetails { get; set; }
        public int? KurlarID { get; set; }
        public virtual Kurlar Kurlar { get; set; }
    }
}
