using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Models
{
  public  class Club
    {

        public int Id { get; set; }
        public string Name { get; set; }

        private ICollection<Employee> employeesInClub { get; set; } = new HashSet<Employee>();
    }
}
