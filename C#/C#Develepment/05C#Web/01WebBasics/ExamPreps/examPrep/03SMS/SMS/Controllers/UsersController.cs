using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using SMS.Models.Users;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(
            Request request,
            IUserService userService
            ) : base(request)
        {
            this.userService = userService;
        }

        public Response Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(UserLoginViewModel model)
        {
            Request.Session.Clear();
            string id = userService.Login(model);

            if (id == null)
            {
                return View(new { ErrorMessage = "Incorrect login" }, "/Error");
            }

            this.SignIn(id);
            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName,Request.Session.Id);

            return this.Redirect("/");

        }

        public Response Register()
        {

            if (this.User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(UserRegisterViewModel model)
        {
            var (isRegistered, error) = userService.Register(model);

            if (isRegistered)
            {
                return Redirect("/Users/Login");
            }

            return this.View(new { ErrorMessage = error }, "/Error");
        }


    }
}
