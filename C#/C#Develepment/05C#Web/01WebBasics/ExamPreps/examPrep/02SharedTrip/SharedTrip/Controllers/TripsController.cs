using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;
        private readonly IRepository repo;
        private readonly IUserService userService;

        public TripsController(
            Request request,
            ITripService tripService,
            IRepository repo
            ) : base(request)
        {
            this.tripService = tripService;
            this.repo = repo;
           
        }

        [Authorize]
        public Response Add()
        {
          
            if (!this.User.IsAuthenticated)
            {
                return View(new { IsAuthorized = false }, "/");
            }

            var model = new
            {
                IsAuthenticated = true,
            };

            return View(model);

        }

        [Authorize]
        [HttpPost]
        public Response Add(TripAddViewModel model)
        {

            if (!this.User.IsAuthenticated)
            {
                return View(new { IsAuthorized = false }, "/");
            }

            this.tripService.AddTrip(model);

            var modelr = new
            {
                IsAuthenticated = true,
                Trips = tripService.GetAllTrips()
            };
        

            return Redirect("/Trips/All");
        }

        private IEnumerable<Trip> GetAllTrips()
        {
            return repo.All<Trip>().AsQueryable();
        }

        [Authorize]
        public Response All()
        {
            var model = new
            {
                IsAuthenticated = true,
                Trips = tripService.GetAllTrips()
            };
            return View(model);
        }

        [Authorize]
        public Response Details(string tripId)
        {
            var trip = repo.All<Trip>().FirstOrDefault(t => t.Id == tripId);

            var Trip = new TripDetailsViewModel()
            {
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = trip.Seats,
                Description = trip.Description,
                ImagePath = trip.ImagePath,
                Id = trip.Id,
                IsAuthenticated = true
               
            };

            return View(Trip);
        }

        [Authorize]
        public Response AddUserToTrip(string tripId)
        {
            var result = tripService.AddTripToUser(tripId, this.User.Id);

            return Redirect("/Trips/All");
        }



    }
}
