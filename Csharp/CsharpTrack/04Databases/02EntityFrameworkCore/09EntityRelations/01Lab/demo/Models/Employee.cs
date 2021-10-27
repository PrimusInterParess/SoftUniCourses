using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo
{
    [Table("People", Schema = "company")]
    [Index()]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Eng { get; set; }


        [Column("FN")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }


        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> Managees { get; set; }

        [Column("StartedOn", TypeName = "date")]
        [Required]
        public DateTime? StartWorkDate { get; set; }

        public decimal Salary { get; set; }


        public int DepartmentId { get; set; }


        private ICollection<EmployeeInClub> employeeInClubs { get; set; } = new List<EmployeeInClub>();


        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employees")]
        public Department Department { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }



        public int? HomeTownId { get; set; }

        [InverseProperty(nameof(Town.NativeCitizens))]
        public Town HomeTown { get; set; }

        public int? WorkTownId { get; set; }


        [InverseProperty(nameof(Town.Workers))]
        public Town WorkTown { get; set; }

    }
}
