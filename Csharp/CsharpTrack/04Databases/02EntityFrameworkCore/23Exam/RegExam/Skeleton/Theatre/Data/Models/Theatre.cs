using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(30)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        /*
         * •	Id – integer, Primary Key
             •	Name – text with length [4, 30] (required)
             •	NumberOfHalls – sbyte between [1…10] (required)
             •	Director – text with length [4, 30] (required)
             •	Tickets - a collection of type Ticket

         */
    }
}
