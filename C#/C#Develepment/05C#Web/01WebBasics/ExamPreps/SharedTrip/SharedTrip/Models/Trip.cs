namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Constants;
    using System;

    using static Constants.GlobalConstants;


    public class Trip
    {
        [Key]
        [Required]
        public string Id { get; private set; }

        [Required]
        [MaxLength(MaxLengthDestination)]
        public string StartPoint { get; private set; }

        [Required]
        [MaxLength(MaxLengthDestination)]
        public string EndPoint { get; private set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [MaxLength(MaxLengthSeats)]
        [Range(2, 6)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(MaxLengthDescription)]
        public string Description { get; set; }

        [Required]
        [MaxLength(MaxLengthUrl)]
        public string ImagePath { get; set; }

        public IEnumerable<UserTrip> UserTrips = new HashSet<UserTrip>();
    }
}
