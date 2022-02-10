using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SharedTrip.Constants;

namespace SharedTrip.Models
{
    public class Trip
    {
        [Key]
        [Required]
        public string Id { get; private set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthDestination)]
        public string StartPoint { get; private set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthDestination)]
        public string EndPoint { get; private set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthSeats)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthDescription)]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthUrl)]
        public string ImagePath { get; set; }

        public IEnumerable<UserTrip> UserTrips = new HashSet<UserTrip>();
    }
}
