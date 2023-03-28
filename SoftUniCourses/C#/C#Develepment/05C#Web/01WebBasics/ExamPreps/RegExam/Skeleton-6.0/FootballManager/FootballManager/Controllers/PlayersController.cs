namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using Contracts;

    using ViewModels.Players;

    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        private readonly IRepository repo;

        public PlayersController(Request request
        , IPlayerService playerService,
        IRepository repo) : base(request)
        {
            this.playerService = playerService;
            this.repo = repo;

        }

        [Authorize]
        public Response All()
        {
            if (User.IsAuthenticated == false)
            {
                return View(new { IsAuthenticated = false }, "/");
            }

            var players = playerService.GetAllPlayers();

            var model = new
            {
                IsAuthenticated = true,
                Players = players
            };
            return View(model);
        }

        [Authorize]
        public Response Add()
        {
            if (User.IsAuthenticated == false)
            {
                return View(new { IsAuthenticated = false }, "/");
            }

            return this.View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(PlayerAddFormModel model)
        {
            var (isValid, errors) = playerService.AddPlayer(model);

            if (isValid)
            {
                return Redirect("/Players/All");
            }

            return this.View(new { IsAuthenticated = true });

        }

        [Authorize]
        public Response AddToCollection(string playerId)
        {
            if (User.IsAuthenticated == false)
            {
                return View(new { IsAuthenticated = false }, "/");
            }

            var isValid = playerService.AddPlayerToUser(playerId, this.User.Id);

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response Collection()
        {
            if (User.IsAuthenticated == false)
            {
                return View(new { IsAuthenticated = false }, "/");
            }

            var players = playerService.GetAllPlayersByUserId(this.User.Id);

            var model = new
            {
                IsAuthenticated = true,
                Players = players

            };

            return View(model);
        }

        [Authorize]
        public Response RemoveFromCollection(string playerId)
        {
            if (User.IsAuthenticated == false)
            {
                return View(new { IsAuthenticated = false }, "/");
            }

            playerService.RemovePlayerFromCollection(playerId, this.User.Id);

            return Redirect("/Players/Collection");
        }
    }
}
