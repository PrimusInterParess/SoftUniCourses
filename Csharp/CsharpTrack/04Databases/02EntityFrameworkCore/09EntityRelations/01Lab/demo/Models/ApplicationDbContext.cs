using System;
using System.Collections.Generic;
using System.Text;
using EfCoreDemo.ModelBuilding;
using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EfCoreDemo
{

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<EmployeeInClub> EmployeesInClubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=EfCoreDemo;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.Entity<EmployeeInClub>().HasKey(k => new {k.EmployeeId, k.ClubId});

            //modelBuilder.Entity<Address>()
            //    .HasOne(a => a.Employee)
            //    .WithOne(e => e.Address);

            //modelBuilder
            //    .Entity<Employee>()
            //    .HasOne(e => e.Department)
            //    .WithMany(d => d.Employees)
            //    .HasForeignKey(c => c.DepartmentId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder
            //    .Entity<Department>()
            //    .HasMany(e => e.Employees)
            //    .WithOne(e => e.Department)
            //    .HasForeignKey(d=>d.DepartmentId);


            modelBuilder
                .Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(e => e.Managees)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}
