using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Contracts;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Trips;


namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }


     //TODO fix visualization

        [Authorize]
        public HttpResponse All()
        {
            IEnumerable<TripListViewModel> trips = tripService.GetAllTrips();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(TripAddViewModel model)
        {
            var (isValid, errors) = tripService.ValidateModel(model);

            if (!isValid)
            {
                return View();
            }

            try
            {
                tripService.AddTrip(model);
            }
            catch (Exception ex)
            {
                return View(
                    new List<ErrorViewModel>() { new ErrorViewModel("Unexpected error when add trip") },
                    "/Error");
            }

            return Redirect("Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            TripDetailsViewModel tripDetailsViewModel = tripService.GetTripDetails(tripId);

            return View(tripDetailsViewModel);
        }
        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            try
            {
                tripService.AddUserToTrip(tripId,this.User.Id);
            }
            catch (ArgumentException aex)
            {
                return View("/Trips/AddUserToTrip");
            }
            catch (Exception ex)
            {
                throw;
            }

            return Redirect("/Trips/All");
        }

    }
}
