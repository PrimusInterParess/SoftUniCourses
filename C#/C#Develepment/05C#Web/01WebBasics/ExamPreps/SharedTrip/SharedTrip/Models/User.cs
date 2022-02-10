using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SharedTrip.Constants;

namespace SharedTrip.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; private set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLength)]
        public string Username { get; private set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLength)]
        public string Password { get; private set; }

        public IEnumerable<UserTrip> UserTrips = new HashSet<UserTrip>();
    }
}
