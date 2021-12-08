using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreDemo.Models
{
  public  class Address
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Employee))]
        public int  EmployeeId { get; set; }

        public Employee  Employee { get; set; }
    }
}
