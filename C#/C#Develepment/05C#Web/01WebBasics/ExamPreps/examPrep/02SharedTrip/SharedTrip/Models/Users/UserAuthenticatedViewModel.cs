using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models.Users
{
    public class UserAuthenticatedViewModel
    {
        public bool IsAuthenticated = true;
        public List<TripListViewModel> Trips { get; set; }
    }
}
