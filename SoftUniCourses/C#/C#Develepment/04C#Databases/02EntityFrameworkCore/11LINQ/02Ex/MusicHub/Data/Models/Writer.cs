using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {

        public Writer()
        {
            this.Songs = new List<Song>();
        }

        public int Id { get; set; }
        [MaxLength(30)]
        public string Pseudonym { get; set; }

        [Required]
        [MaxLength(20)]

        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }

        /*
         *•	Id – Integer, Primary Key
        •	Pseudonym – text
        •	Name – text with max length 20 (required)
        •	Songs – collection of type Song

         *
         */
    }
}
