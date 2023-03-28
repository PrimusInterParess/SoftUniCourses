using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            this.Casts = new HashSet<Cast>();
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        public TimeSpan Duration { get; set; }

        [MaxLength(10)]
        public float Rating { get; set; }

        [Required]
        [MaxLength(4)]
        public Genre Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MaxLength(30)]
        public string Screenwriter { get; set; }

        
        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        /*
         *•
       •	
       •	
       •
       •	
       •	
       •	Casts - a collection of type Cast
       •	Tickets - a collection of type Ticket

         *
         *
         *
         */
    }
}
