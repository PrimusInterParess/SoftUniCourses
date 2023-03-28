namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using Contracts;
    using ViewModels.Users;
    public class UsersController : Controller
    {

        private readonly IUserService userService;
        private readonly IPlayerService playerService;

        public UsersController(
            Request request,
            IUserService userService,
            IPlayerService playerService)
            : base(request)
        {
            this.userService = userService;
            this.playerService = playerService;
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(UserRegisterFormModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            var (isRegistered, errors) = this.userService.RegisterUser(model);

            if (isRegistered == false)
            {
                return this.View(new { IsAuthenticated = false });

            }

            return Redirect("/Users/Login");
        }


        public Response Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Players/All");

            }

            return this.View(new { IsAuthenticated = false });
        }


        [HttpPost]
        public Response Login(UserLoginFormModel model)
        {

            var modelAuthenticated = new
            {
                IsAuthenticated = true,
                Players = this.playerService.GetAllPlayers()
            };

            if (this.User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            Request.Session.Clear();
            string id = this.userService.LoginUser(model);

            if (id == null)
            {
                return View(new { IsAuthenticated = false });
            }

            this.SignIn(id);
            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response Logout()
        {
            if (this.User.IsAuthenticated == false)
            {
                return Redirect("/");

            }

            this.SignOut();

            return Redirect("/");
        }
    }
}
