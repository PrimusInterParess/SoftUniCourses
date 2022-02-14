using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Contracts;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.TripsFormModels;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public TripsController(
            IValidator validator, 
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripAddFormModel model)
        {
            var result = validator.ValidateTripAddFormModel(model);

            HttpResponse responseToReturn = null;


            if (result.isValid == false)
            {
                responseToReturn = Redirect("/Trips/Add");
            }
            else
            {
                Trip trip = CreateTrip(model);

                AddUserToTrip(trip);
                AddTripToDatabase(trip);

                responseToReturn = Redirect("/Trips/All");
            }

            return responseToReturn;
        }

        private void AddUserToTrip(Trip trip)
        {
            var userID = this.User.Id;

            trip.UserTrips.Add(new UserTrip()
            {
                UserId = userID,
                TripId = trip.Id
            });

        }

        private void AddTripToDatabase(Trip trip)
        {
            this.data.Trips.Add(trip);
            this.data.SaveChanges();
        }

        private Trip CreateTrip(TripAddFormModel model)
        {
            return new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = ConvertDateTime(model.DepartureTime),
                ImagePath = model.ImagePath,
                Description = model.Description,
                Seats = model.Seats
            };
        }

        private DateTime ConvertDateTime(string modelDepartureTime)
        {
            DateTime date;

            DateTime.TryParseExact(modelDepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out date);

            return date;
        }

        public HttpResponse All()
        {
            return View();
        }

        public HttpResponse Details()
        {
            return View();
        }

        public HttpResponse Logout()
        {
            return View();

        }
    }
}
