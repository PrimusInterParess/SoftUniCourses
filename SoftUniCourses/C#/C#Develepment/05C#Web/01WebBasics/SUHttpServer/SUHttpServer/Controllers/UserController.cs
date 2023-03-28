namespace SUHttpServer.Demo.Controllers
{
    using SUHttpServer.Controllers;
    using SUHttpServer.Server.HTTP;
    using HTTP;

    public class UserController : Controller
    {
        private const string Username = "user";

        private const string Password = "user123";

       

        public UserController(Request request) : base(request)
        {

        }

        public Response Login()
            => View();

        public Response LoginUser()
        {
            Request.Session.Clear();

            var usernameMatches = Request.Form["Username"] == UserController.Username;
            var passwordMatches = Request.Form["Password"] == UserController.Password;

            if (usernameMatches && passwordMatches)
            {
                if (!this.Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();

                    cookies.Add(Session.SessionCookieName, this.Request.Session.Id);

                    return Html("<h3>Logged successfully!</h3>", cookies);
                }

                return Html("<h3>Logged successfully!</h3>");
            }

            return Redirect("/Login");
        }

        public Response Logout()
        {
            this.Request.Session.Clear();

            return Html("<h3>Logged out successfully!</h3>");
        }

        public Response GetUserData()
        {

            if (this.Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logged-in user is " + $"with username '{UserController.Username}'</h3>");
            }

            return Redirect("/Login");
        }
    }
}
