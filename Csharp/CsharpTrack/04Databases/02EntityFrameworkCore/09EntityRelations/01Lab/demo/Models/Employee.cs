using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo
{
   // [Table("People",Schema = "company")] renaming attribute for table name and schema

  // [Index("EGN",IsUnique = true,Name = "IX_Egn")] for fast search
    public class Employee
    {
        public Employee(int eid, string egn, string firstName, string lastName, DateTime? startWorkDate, decimal salary, int did, Department department, int? addressId, Address address, ICollection<EmployeeInClub> clubParticipations)
        {
            EID = eid;
            EGN = egn;
            FirstName = firstName;
            LastName = lastName;
            StartWorkDate = startWorkDate;
            Salary = salary;
            DID = did;
            Department = department;
            AddressId = addressId;
            Address = address;
            ClubParticipations = clubParticipations;
        }

        public int EID { get; set; }
        public string EGN { get; set; }


     //  [Column("FN")] renaming attribute for column
        public string FirstName { get; set; }
        public string LastName { get; set; }

       // [NotMapped]
        public string FullName => FirstName + " " + LastName;

      //  [Column(TypeName = "date")] attribute for changing column type
        public DateTime? StartWorkDate { get; set; }
        public decimal Salary { get; set; }

        public int DID { get; set; }

    //    [ForeignKey(nameof(DID))]
        public Department Department { get; set; }

        //when one to one relation it has to has to be nullable and has to have ForeignKey referring the column
        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }

        public Address Address { get; set; }

        private ICollection<EmployeeInClub> ClubParticipations { get; set; }

        public int? BirthTownId { get; set; }

        [InverseProperty(nameof(Town.NativeCitizens))]
        public Town BirthTown { get; set; }

        public int? WorkTownId { get; set; }

        [InverseProperty(nameof(Town.Workers))]  
        public Town WorkTown { get; set; }

    }
}
