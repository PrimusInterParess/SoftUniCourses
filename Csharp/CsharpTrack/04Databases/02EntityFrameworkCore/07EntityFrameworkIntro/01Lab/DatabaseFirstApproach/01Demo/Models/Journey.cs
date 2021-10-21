using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class Journey
    {
        public Journey()
        {
            TravelCards = new HashSet<TravelCard>();
        }

        public int Id { get; set; }
        public DateTime JourneyStart { get; set; }
        public DateTime JourneyEnd { get; set; }
        public string Purpose { get; set; }
        public int DestinationSpaceportId { get; set; }
        public int SpaceshipId { get; set; }

        public virtual Spaceport DestinationSpaceport { get; set; }
        public virtual Spaceship Spaceship { get; set; }
        public virtual ICollection<TravelCard> TravelCards { get; set; }
    }
}
