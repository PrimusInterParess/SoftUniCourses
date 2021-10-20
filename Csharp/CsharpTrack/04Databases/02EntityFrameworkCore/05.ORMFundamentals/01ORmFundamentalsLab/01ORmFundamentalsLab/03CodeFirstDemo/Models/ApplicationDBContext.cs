using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace _03CodeFirstDemo.Models
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=CodeFirstDemo2021");
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<News> News { get; set; }
    }
}
