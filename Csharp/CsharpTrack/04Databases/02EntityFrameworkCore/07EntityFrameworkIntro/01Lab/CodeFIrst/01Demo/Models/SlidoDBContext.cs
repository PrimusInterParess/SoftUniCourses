using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace _01Demo.Models
{
    public class SlidoDBContext : DbContext

    {
        public SlidoDBContext()
        {

        }

        public SlidoDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=Slido");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().Property(x => x.Content).IsUnicode(false);
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
