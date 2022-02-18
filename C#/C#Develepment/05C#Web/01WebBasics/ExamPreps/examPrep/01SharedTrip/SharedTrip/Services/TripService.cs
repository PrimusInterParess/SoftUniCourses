using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedTrip.Contracts;
using SharedTrip.Data.Models;
using SharedTrip.Models.ErrorViewModels;
using SharedTrip.Models.Trips;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;
        private readonly IValidationService validation;
        public TripService(IValidationService validation, IRepository repo)
        {
            this.validation = validation;
            this.repo = repo;
        }
        public (bool, ICollection<ErrorViewModel>) AddTrip(TripAddViewModel model)
        {
            var (isValid, errors) = validation.ValidateModel(model);

            if (isValid==false)
            {
                return (isValid, errors);
            }

            var (isValidDate,date) = validation.ValidateDate(model.DepartureTime);

            if (isValidDate==false)
            {
                errors.Add(new ErrorViewModel("Invalid date"));

                return (isValidDate, errors);
            }

            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = date,
                ImagePath = model.ImagePath,
                Description = model.Description
            };

            try
            {
                repo.Add(trip);
                repo.SaveChanges();

                isValid = true;
            }
            catch (Exception)
            {
                isValid = false;
            }

            return (isValid, errors);
        }

        public IEnumerable<TripListViewModel> GetAllTrips()
        {
            return repo.All<Trip>().Select(t=>new TripListViewModel()
            {
                Id = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = t.Seats
            });
        }
    }
}
