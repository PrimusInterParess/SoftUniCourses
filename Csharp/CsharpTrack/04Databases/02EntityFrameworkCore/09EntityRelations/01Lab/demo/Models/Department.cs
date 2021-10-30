using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Models
{
  public  class Department
    {

        public Department()
        {
            this.EmployeesInDepartment = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        //inversedProperty

        public ICollection<Employee> EmployeesInDepartment { get; set; }
    }
}
