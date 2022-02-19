using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contracts;
using Git.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class UsersController:Controller
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
                return Redirect("/Repositories/All");
            }

            return this.View(new { IsAuthenticated = false });
        }
        [HttpPost]
        public Response Login(UserLoginViewModel model)
        {
           
        }



    }
}
