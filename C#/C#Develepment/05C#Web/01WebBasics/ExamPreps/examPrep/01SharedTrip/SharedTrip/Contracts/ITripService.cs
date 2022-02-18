using System.Collections.Generic;
using SharedTrip.Models.ErrorViewModels;
using SharedTrip.Models.Trips;
using SharedTrip.Models.Users;

namespace SharedTrip.Contracts;

public interface ITripService
{
    (bool, ICollection<ErrorViewModel>) AddTrip(TripAddViewModel model);

    IEnumerable<TripListViewModel> GetAllTrips();

}