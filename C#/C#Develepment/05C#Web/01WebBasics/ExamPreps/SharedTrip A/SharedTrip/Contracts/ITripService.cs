using System.Collections.Generic;
using SharedTrip.Models;
using SharedTrip.Models.Trips;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        public (bool isValid, ICollection<ErrorViewModel>) ValidateModel(TripAddViewModel model);


        void AddTrip(TripAddViewModel model);
        IEnumerable<TripListViewModel> GetAllTrips();
        TripDetailsViewModel GetTripDetails(string tripId);
        void AddUserToTrip(string tripId, string userId);
    }
}