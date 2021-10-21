using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int EmployeeCount { get; set; }
        public decimal? BaseRate { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
