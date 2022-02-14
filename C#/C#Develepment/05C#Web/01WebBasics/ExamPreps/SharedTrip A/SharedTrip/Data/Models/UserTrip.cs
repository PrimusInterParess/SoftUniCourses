using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string TripId { get; set; }

        [Required]
        [ForeignKey(nameof(TripId))]
        public Trip Trip { get; set; }
    }

    //•	Has UserId – a string
    //    •	Has User – a User object
    //    •	Has TripId– a string
    //    •	Has Trip – a Trip object

}
