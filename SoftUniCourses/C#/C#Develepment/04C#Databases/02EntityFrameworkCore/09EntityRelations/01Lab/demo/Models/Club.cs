using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Models
{
    public class Club
    {
        public Club(int id, string name, ICollection<EmployeeInClub> employeeInClub)
        {
            Id = id;
            Name = name;
            this.employeeInClub = employeeInClub;//????????????  
        }
        public int Id { get; set; }
        public string Name { get; set; }

        private ICollection<EmployeeInClub> employeeInClub { get; set; }
    }
    }
}
