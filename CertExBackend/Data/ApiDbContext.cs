using CertExBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<CertificationProvider> CertificationProviders { get; set; }
        public DbSet<CategoryTag> CategoryTags { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CertificationExam> CertificationExams { get; set; }
        public DbSet<CertificationTag> CertificationTags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<ExamDetail> ExamDetails { get; set; }
        public DbSet<MyCertification> MyCertifications { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<CriticalCertification> CriticalCertifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(m => m.Subordinates)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.SetNull); // Optional: Set null on delete

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.SSOEmployeeId)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.ManagerId);

            // Configure the relationship for DepartmentHead
            modelBuilder.Entity<Department>()
                .HasOne(d => d.DepartmentHead)
                .WithMany() // Employee does not need to reference back to Departments
                .HasForeignKey(d => d.DepartmentHeadId)
                .OnDelete(DeleteBehavior.SetNull); // Optional: Set null on delete
        }
    }
}
