using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models.TripsFormModels
{
    public class TripAddFormModel
    {
        public string StartPoint { get; init; }

        public string EndPoint { get; init; }

        public string DepartureTime { get; init; }

        public string ImagePath { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }

    }
}
