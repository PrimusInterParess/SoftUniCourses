using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedTrip.Models
{
    public class UserTrip
    {
     
        public string UserId { get; private set; }

        [ForeignKey(nameof(UserId))]

        public User User { get; private set; }

       
        public string TripId { get; private set; }

        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; private set; }
    }
}
