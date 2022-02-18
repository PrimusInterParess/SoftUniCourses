using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models.Users;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(
            Request request,IUserService _userService) : base(request)
        {
            this.userService = _userService;
        }

        public Response Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return this.View(new { IsAuthenticated = false });
        }


        [HttpPost]
        public Response Login(UserLoginViewModel model)
        {

            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            Request.Session.Clear();
            string id = this.userService.LoginUser(model);

            if (id == null)
            {
                return View(new { ErrorMessage = "Incorrect login" }, "/Error");
            }

            this.SignIn(id);
            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);

            return View(this.User, "/Trips/All");

        }


        public Response Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

          
          
            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(UserRegisterViewModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            var (isRegistered, errors) = this.userService.RegisterUser(model);

            if (isRegistered==false)
            {
                return this.View(new { IsAuthenticated = false });
            }

            return this.View(new { IsAuthenticated = false },"/Users/Login");
        }
    }
}
