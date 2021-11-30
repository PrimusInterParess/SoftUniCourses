using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
   public class EmployeeTask
    {
        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int TaskId { get; set; }

        public Task Task { get; set; }


        /*
         *•	EmployeeId - integer, Primary Key, foreign key
        •	Employee -  Employee
        •	TaskId - integer, Primary Key, foreign key 
        •	Task - Task
         *
         */
    }
}
