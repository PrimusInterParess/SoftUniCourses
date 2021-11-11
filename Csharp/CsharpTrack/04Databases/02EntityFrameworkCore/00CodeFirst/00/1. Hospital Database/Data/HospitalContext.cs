using System;
using System.Collections.Generic;
using System.Text;

using P01_HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {

        public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
        {

        }

        public HospitalContext()
        {

        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Doctor> Doctor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=Hospital;");
            }



            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(k => new { k.PatientId, k.MedicamentId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
