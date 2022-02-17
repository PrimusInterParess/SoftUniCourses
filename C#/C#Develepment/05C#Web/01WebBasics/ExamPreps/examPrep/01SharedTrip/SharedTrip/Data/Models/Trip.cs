using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedTrip.Models;
using static  SharedTrip.Constants.VerificationConstants;
namespace SharedTrip.Data.Models
{
    public class Trip
    {
        [Key] 
        [Required] 
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string  StartPoint { get; set; }
        [Required]
        public string  EndPoint { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        [Range(SeatsMinValue,SeatsMaxValue)]
        public int Seats { get; set; }
        [Required]
        [MaxLength(StringMaxLength)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; } = new List<UserTrip>();




    }
}
