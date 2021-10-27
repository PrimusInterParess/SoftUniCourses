using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.ModelBuilding
{
  public class EmployeeConfiguration :IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.Ignore(i => i.FullName);


            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(20);


            builder
                 .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(30);

            //builder
            //     .HasKey(k => new { k.Id, k.Eng });

            builder
                 .Property(p => p.StartWorkDate)
                .HasColumnName("StartedOn");

           

            //builder
            //       .HasOne(e => e.Department)
            //    .WithMany(d => d.Employees)
            //    .HasForeignKey(d => d.DepartmentId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
