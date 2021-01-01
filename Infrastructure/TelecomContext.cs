using System;
using DataAnalyse.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


#nullable disable

namespace DataAnalyse.Infrastructure
{
    public partial class TelecomContext : DbContext
    {
        // public TelecomContext()
        // {
        // }

        public TelecomContext(DbContextOptions<TelecomContext> options) : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Phoneinfo> Phoneinfos { get; set; }
        public virtual DbSet<User> Users { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseMySql(
//                     "server=10.132.221.130;database=telecom;user=stu_readonly;password=stu_readonly;treattinyasboolean=true",
//                     Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.7.32-mysql"));
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("location");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Latitude)
                    .HasColumnType("float(255,10)")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("float(255,10)")
                    .HasColumnName("longitude");

                entity.Property(e => e.Province)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("province")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Phoneinfo>(entity =>
            {
                entity.HasKey(e => e.Phone)
                    .HasName("PRIMARY");

                entity.ToTable("phoneinfo");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AreaCode)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("area_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CityCode)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("city_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Isp)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("isp")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PostCode)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("post_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Prefix)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("prefix")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Province)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("province")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new {e.Phone, e.Idno})
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] {0, 0});

                entity.ToTable("user");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Idno)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("idno")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("datetime")
                    .HasColumnName("birthdate");

                entity.Property(e => e.BloodGroup)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("blood_group")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Job)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("job")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Latitude)
                    .HasColumnType("float(20,10)")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("float(20,10)")
                    .HasColumnName("longitude");

                entity.Property(e => e.Mail)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("mail")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PricingPackage)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("pricing_package")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Province)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("province")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sex)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("sex")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}