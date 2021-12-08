using System;
using System.Collections.Generic;

#nullable disable

namespace _01Demo.Models
{
    public partial class TravelCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string JobDuringJourney { get; set; }
        public int ColonistId { get; set; }
        public int JourneyId { get; set; }

        public virtual Colonist Colonist { get; set; }
        public virtual Journey Journey { get; set; }
    }
}
