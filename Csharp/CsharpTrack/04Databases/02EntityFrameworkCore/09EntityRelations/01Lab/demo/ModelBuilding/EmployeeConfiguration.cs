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
            //changing name of table in database
            builder
                .ToTable("People", "company");

            //changing name of column in database and setting column data type
            builder
                .Property(x => x.StartWorkDate)
                .HasColumnName("StartedOn")
                .HasColumnType("DATE");


            //setting primary key,when differs from EID
            builder
                .HasKey(c => c.EID);

            //setting compose primary key
            builder
                .HasKey(c => new { Id = c.EID, c.EGN });


            //setting property to be Required instead of nullable when nullable
            builder
                .Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            //setting property to be Required instead of nullable when nullable and setting length
            builder
                .Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(20);

            //ignoring property not to be initialise in database
            builder.Ignore(f => f.FullName);

            //when you don't want default behaviour of navigation properties use fluent API

            builder
                .HasOne(e => e.Department)
                .WithMany(d => d.EmployeesInDepartment)
                .HasForeignKey(d => d.DID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
