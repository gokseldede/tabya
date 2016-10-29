using Project_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"server=188.121.44.214;database=Db_Tabya;UID=1ki3;PWD=Magic89!;";
            //  Database.Connection.ConnectionString = @"server=DESKTOP-3GINP1N;database=Db_Tabya;integrated security=true;";
        }
        public DbSet<Newsletter> Newsletter { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<AdDetail> AdDetails { get; set; }
        public DbSet<Global> Globals { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Properties> Propertiesis { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Semt> Semtler { get; set; }
        public DbSet<Status> Statues { get; set; }
        public DbSet<Isinma> Isınmalar { get; set; }
        public DbSet<Kredi> Krediler { get; set; }
        public DbSet<Kullanım> Kullanımlar { get; set; }
        public DbSet<Esya> Esyalar { get; set; }
        public DbSet<EmlakTip> EmlakTips { get; set; }
        public DbSet<AdProp> AdProps { get; set; }
        public DbSet<FileDetail> FileDetails { get; set; }
        public DbSet<WorkFileDetail> WorkFileDetails { get; set; }
        public DbSet<ProjectFile> ProjectFiles { get; set; }
        public DbSet<SocialApps> SocialApps { get; set; }
        public DbSet<Securitys> Security { get; set; }
        public DbSet<Kimden> Kimden { get; set; }
        public DbSet<Workplace> Workplace { get; set; }
        public DbSet<Land> Land { get; set; }
        public DbSet<LandFileDetail> LandFileDetails { get; set; }
        public DbSet<Imar> Imar { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<Bina> Bina { get; set; }
        public DbSet<BinaFileDetail> BinaFileDetail { get; set; }
        public DbSet<Kurlar> Kurlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
