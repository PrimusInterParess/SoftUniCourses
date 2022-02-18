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

            return this.View(this.User,"/Trips/Add");
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

            var trips = tripService.GetAllTrips();

            return this.View(trips, "/Trips/All");
        }

        private IEnumerable<Trip> GetAllTrips()
        {
            return repo.All<Trip>().AsQueryable();
        }

        [Authorize]
        public Response All()
        {
            if (!this.User.IsAuthenticated)
            {
                return View(new { IsAuthorized = false }, "/");
            }

            return this.View(this.User, "/Trips/All");
        }


    }
}
