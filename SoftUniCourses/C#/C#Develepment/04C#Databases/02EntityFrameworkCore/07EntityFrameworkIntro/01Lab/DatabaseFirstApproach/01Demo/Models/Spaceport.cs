using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class Spaceport
    {
        public Spaceport()
        {
            Journeys = new HashSet<Journey>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
        public virtual ICollection<Journey> Journeys { get; set; }
    }
}
