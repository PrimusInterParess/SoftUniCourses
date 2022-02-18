using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SharedTrip.Constants.GlobalConstants;
namespace SharedTrip.Models.Trips
{
    public class TripAddViewModel
    {
        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        [StringLength(DefaultStringMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(SeatsMinValue, SeatsMaxValue)]
        public string Seats { get; set; }

        public string ImagePath { get; set; }
    }
}
