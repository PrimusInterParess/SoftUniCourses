using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Trips;
using static SharedTrip.Constants.GlobalConstants;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;

        public TripService(IRepository repo)
        {
            this.repo = repo;
        }

        public (bool isValid, ICollection<ErrorViewModel>) ValidateModel(TripAddViewModel model)
        {
            bool isValid = true;

            ICollection<ErrorViewModel> errors = new List<ErrorViewModel>();

            DateTime date;

            if (string.IsNullOrWhiteSpace(model.StartPoint) ||
                string.IsNullOrWhiteSpace(model.EndPoint) ||
                string.IsNullOrWhiteSpace(model.DepartureTime) ||
                string.IsNullOrWhiteSpace(model.Description))
            {
                isValid = false;

                errors.Add(
                    new ErrorViewModel("Required fields are : 'Start Point','End Point','Departure time','Description'"));
            }

            if (model.Seats < MinSeatsValue ||
                model.Seats > MaxSeatsValue)
            {
                isValid = false;

                errors.Add(
                    new ErrorViewModel($"Seats should be  between {MinSeatsValue} and {MaxSeatsValue}"));
            }

            if (model.Description.Length > DefaultStringMaxLength)
            {

                isValid = false;

                errors.Add(new ErrorViewModel(
                    $"Description should be not more than {DefaultStringMaxLength} characters long"));
            }

            if (!DateTime.TryParseExact(
                    model.DepartureTime,
                    "dd.MM.yyyy HH:mm",
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.None,
                    out date))
            {
                isValid = false;

                errors.Add(new ErrorViewModel("Invalid departure time"));
            }

            return (isValid, errors);
        }

        public void AddTrip(TripAddViewModel model)
        {
            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = ConvertDate(model.DepartureTime),
                Seats = model.Seats,
                Description = model.Description
            };

            repo.Add(trip);

            repo.SaveChanges();
        }

        public IEnumerable<TripListViewModel> GetAllTrips()
        {
            return repo.All<Trip>()
                .Select(t => new TripListViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats
                });
        }

        public TripDetailsViewModel GetTripDetails(string tripId)
        {
            return repo.All<Trip>().Where(t=>t.Id==tripId).Select(t => new TripDetailsViewModel()
            {
                Id = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = t.Seats,
                ImagePath = t.ImagePath
            }).FirstOrDefault();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var user = repo.All<User>().FirstOrDefault(u=>u.Id==userId);
            var trip = repo.All<Trip>().FirstOrDefault(t=>t.Id==tripId);

            if (user==null|| trip==null)
            {
                throw new ArgumentException("Screw you!");
            }

            user.UserTrips.Add(new UserTrip()
            {
                Trip = trip,
                User = user
            });

           

            repo.SaveChanges();
        }


        private DateTime ConvertDate(string inputData)

        {
            DateTime date;

            DateTime.TryParseExact(
                inputData,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);

            return date;
        }
    }
}
