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
#if DEBUG
            Database.Connection.ConnectionString = @"server=WIN-Q8TU8RLSD8L\SQLEXPRESS;database=Db_Tabya;integrated security=true;";
#else
            Database.Connection.ConnectionString = @"server=188.121.44.214;database=Db_Tabya;UID=1ki3;PWD=Magic89!;";
#endif
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
        public DbSet<Kullanim> Kullanimlar { get; set; }
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

            #region AdDetail Mappings
            modelBuilder.Entity<AdDetail>()
                .HasMany<Properties>(s => s.Propertieses)
                .WithMany(p => p.AdDetailses)
                .Map(ap =>
                {
                    ap.MapLeftKey("AdDetail_ID");
                    ap.MapRightKey("Properties_ID");
                    ap.ToTable("AdDetailProperties");
                });

            modelBuilder.Entity<AdDetail>()
               .HasMany<SocialApps>(s => s.SocialAppses)
               .WithMany(p => p.AdDetailses)
               .Map(ap =>
               {
                   ap.MapLeftKey("AdDetail_ID");
                   ap.MapRightKey("SocialApps_ID");
                   ap.ToTable("AdDetailSocialApps");
               });

            modelBuilder.Entity<AdDetail>()
               .HasMany<Securitys>(s => s.Securities)
               .WithMany(p => p.AdDetailses)
               .Map(ap =>
               {
                   ap.MapLeftKey("AdDetail_ID");
                   ap.MapRightKey("Security_ID");
                   ap.ToTable("AdDetailSecurities");
               });
            #endregion

            #region Building Mappings
            modelBuilder.Entity<Bina>()
               .HasMany<Properties>(s => s.Propertieses)
               .WithMany(p => p.Binas)
               .Map(ap =>
               {
                   ap.MapLeftKey("Bina_ID");
                   ap.MapRightKey("Properties_ID");
                   ap.ToTable("BinaProperties");
               });

            modelBuilder.Entity<Bina>()
               .HasMany<SocialApps>(s => s.SocialAppses)
               .WithMany(p => p.Binas)
               .Map(ap =>
               {
                   ap.MapLeftKey("Bina_ID");
                   ap.MapRightKey("SocialApps_ID");
                   ap.ToTable("BinaSocialApps");
               });

            modelBuilder.Entity<Bina>()
               .HasMany<Securitys>(s => s.Securities)
               .WithMany(p => p.Binas)
               .Map(ap =>
               {
                   ap.MapLeftKey("Bina_ID");
                   ap.MapRightKey("Security_ID");
                   ap.ToTable("BinaSecurities");
               });
            #endregion

            #region Workplace Mappings
            modelBuilder.Entity<Workplace>()
               .HasMany<Properties>(s => s.Propertieses)
               .WithMany(p => p.Workplaces)
               .Map(ap =>
               {
                   ap.MapLeftKey("Workplace_ID");
                   ap.MapRightKey("Properties_ID");
                   ap.ToTable("WorkplaceProperties");
               });

            modelBuilder.Entity<Workplace>()
               .HasMany<SocialApps>(s => s.SocialAppses)
               .WithMany(p => p.Workplaces)
               .Map(ap =>
               {
                   ap.MapLeftKey("Workplace_ID");
                   ap.MapRightKey("SocialApps_ID");
                   ap.ToTable("WorkplaceSocialApps");
               });

            modelBuilder.Entity<Workplace>()
               .HasMany<Securitys>(s => s.Securities)
               .WithMany(p => p.Workplaces)
               .Map(ap =>
               {
                   ap.MapLeftKey("Workplace_ID");
                   ap.MapRightKey("Security_ID");
                   ap.ToTable("WorkplaceSecurities");
               });
            #endregion

            #region Project Mappings
            modelBuilder.Entity<Project>()
               .HasMany<Properties>(s => s.Propertieses)
               .WithMany(p => p.Projects)
               .Map(ap =>
               {
                   ap.MapLeftKey("Project_ID");
                   ap.MapRightKey("Properties_ID");
                   ap.ToTable("ProjectProperties");
               });

            modelBuilder.Entity<Project>()
               .HasMany<SocialApps>(s => s.SocialAppses)
               .WithMany(p => p.Projects)
               .Map(ap =>
               {
                   ap.MapLeftKey("Project_ID");
                   ap.MapRightKey("SocialApps_ID");
                   ap.ToTable("ProjectSocialApps");
               });

            modelBuilder.Entity<Project>()
               .HasMany<Securitys>(s => s.Securities)
               .WithMany(p => p.Projects)
               .Map(ap =>
               {
                   ap.MapLeftKey("Project_ID");
                   ap.MapRightKey("Security_ID");
                   ap.ToTable("ProjectSecurities");
               });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }

}
