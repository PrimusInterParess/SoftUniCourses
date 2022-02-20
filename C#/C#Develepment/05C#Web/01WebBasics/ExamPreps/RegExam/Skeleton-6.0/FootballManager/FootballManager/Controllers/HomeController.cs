
namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using Contracts;

    public class HomeController : Controller
    {
        private readonly IPlayerService playerService;
        public HomeController(Request request
        ,IPlayerService playerService)
            : base(request)
        {
            this.playerService = playerService;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
              return Redirect("/Players/All");
            }
            return this.View(new { IsAuthenticated = false });
        }
    }
}
