using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
   public class Producer
    {

        public Producer()
        {
            this.Albums = new List<Album>();
            
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

      
        [MaxLength(50)]
        public string Pseudonym { get; set; }

        [MaxLength(20)]

        public string PhoneNumber { get; set; }

        public ICollection<Album> Albums { get; set; }

        /*
         *
         *•	Id – Integer, Primary Key
          •	Name – text with max length 30 (required)
          •	Pseudonym – text
          •	PhoneNumber – text
          •	Albums – collection of type Album

         *
         *
         */
    }
}
