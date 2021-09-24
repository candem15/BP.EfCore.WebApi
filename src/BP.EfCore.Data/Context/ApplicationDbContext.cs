using BP.EfCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Bp.EfCore.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-59ACA5K;Initial Catalog=efcore;User ID=eray;Password=Ab112233");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.Number).HasColumnName("number");
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
                entity.Property(i => i.AddressId).HasColumnName("address_id").HasColumnType("int");
                entity.HasMany(i=>i.Books).WithOne(i=>i.Student).HasForeignKey(p=>p.StudentId).HasConstraintName("student_studentBook_id_fk");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn();
                entity.Property(i => i.Name).HasColumnName("name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.IsActive).HasColumnName("is_active");
            });
            modelBuilder.Entity<StudentAddress>(entity =>
           {
               entity.ToTable("student_addresses");

               entity.Property(i => i.Id).HasColumnName("id").UseIdentityColumn();
               entity.Property(i => i.City).HasColumnName("name").HasColumnType("nvarchar").HasMaxLength(100);
               entity.Property(i => i.District).HasColumnName("district").HasColumnType("nvarchar").HasMaxLength(100);
               entity.Property(i => i.Country).HasColumnName("country").HasColumnType("nvarchar").HasMaxLength(50);
               entity.Property(i => i.FullAddress).HasColumnName("full_address").HasColumnType("nvarchar");
               entity.HasOne(i=>i.Student).WithOne(i=>i.StudentAddress).HasForeignKey<Student>(i=>i.AddressId).HasConstraintName("studentAdresses_student_id_fk");
           });
        }
    }
}