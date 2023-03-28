using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class Room
    {
        public Room()
        {
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int Beds { get; set; }
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
