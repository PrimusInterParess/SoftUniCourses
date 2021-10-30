using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Models
{
    public class EmployeeInClub
    {
        public Employee Employee { get; set; }
        public Club Club { get; set; }

        public DateTime JoinDate  { get; set; }
    }
}
