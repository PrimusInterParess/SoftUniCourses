

using System;
using System.Collections;
using System.Collections.Generic;
using SharedTrip.Constants;

namespace SharedTrip.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants;


    public class User
    {
        [Key] 
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(DefaultStringMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(DefaultStringMaxLength)]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; } = new HashSet<UserTrip>();


    }
}
