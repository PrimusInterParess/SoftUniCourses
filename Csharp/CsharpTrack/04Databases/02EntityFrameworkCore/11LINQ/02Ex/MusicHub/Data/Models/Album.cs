using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {

        public int Id { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price => Songs.Sum(s => s.Price);

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public int? ProducerId { get; set; }

        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; }
        /*
         * •	Id – Integer, Primary Key
           •	ReleaseDate – Date (required)
           •	Price – calculated property (the sum of all song prices in the album)
           •	Name – Text with max length 40 (required)
           •	ProducerId – integer, Foreign key
           •	Producer – the album’s producer
           •	Songs – collection of all Songs in the Album 

         */

    }
}
