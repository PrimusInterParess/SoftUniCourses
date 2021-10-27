using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Models
{
  public  class Department
    {

        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
