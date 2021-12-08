using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
  public  class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }

        public int  Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }

        /* 
         *•	Id - integer, Primary Key
          •	Name - text with length [2, 40] 
          •	OpenDate - date and time 
          •	DueDate - date and time 
          •	Tasks - collection of type Task

         *
         *
         */
    }
}
