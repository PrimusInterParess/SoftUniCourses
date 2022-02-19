using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Data.Models;
namespace SharedTrip.Controllers
{

    public class HomeController : Controller
    {

        private readonly IUserService userService;
        private readonly ITripService tripService;
        private readonly IRepository repo;
        public HomeController(Request request,IUserService userService,ITripService tripService,IRepository repo)
            : base(request)
        {
            this.userService = userService;
            this.tripService = tripService;
            this.repo = repo;

        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return this.View(
                new
                {
                    IsAuthenticated = false
                });
        }

     
    }
}