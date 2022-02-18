using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace SharedTrip.Controllers
{

    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                return View(this.User,"/Trips/All");
            }

            return this.View(
                new
                {
                    IsAuthenticated = false
                });
        }

     
    }
}