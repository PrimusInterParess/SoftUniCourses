using System.Collections.Generic;
using SharedTrip.Constants;

namespace SharedTrip.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants;


    public class Trip
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string StartPoint { get; set; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [Range(SeatsMinValue,SeatsMaxValue)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(DefaultStringMaxLength)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; } = new HashSet<UserTrip>();

    }
}
