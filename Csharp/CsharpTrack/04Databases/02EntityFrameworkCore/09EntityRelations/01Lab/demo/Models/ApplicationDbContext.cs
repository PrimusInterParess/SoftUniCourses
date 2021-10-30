using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<EmployeeInClub> EmployeeInClubs { get; set; }



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

            modelBuilder.Entity<Department>().Property(c => c.Name).IsRequired().HasMaxLength(50);


            modelBuilder.Entity<EmployeeInClub>().HasKey(k => new {k.Club, k.Employee});

            //fluentAPI for describing relation between two columns => one-to-one relation
            //modelBuilder
            //    .Entity<Address>()
            //    .HasOne(a => a.Employee)
            //    .WithOne(e => e.Address)
            //    .OnDelete(DeleteBehavior.NoAction);


            //fluentAPI for describing relation between two columns ,you could go either ways from department or employee=> one-to-many relation
            //modelBuilder.Entity<Department>()
            //    .HasMany(d => d.EmployeesInDepartment)
            //    .WithOne(e => e.Department)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .HasForeignKey(d=>d.DID);




            base.OnModelCreating(modelBuilder);
        }
    }
}
