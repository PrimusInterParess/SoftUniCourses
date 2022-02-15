
using System;
using System.Collections.Generic;
using MyWebServer.Controllers;
using MyWebServer.Http;
using MyWebServer.Http.Collections;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.Users;


namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        => View();

        [HttpPost]
        public HttpResponse Login(LoginViewModel model)
        {

            (string userId, bool isCorrect) = userService.IsLoginCorrect(model);

            if (isCorrect)
            {
                SignIn(userId);

                return Redirect("/Trips/All");
            }

            return View();
        }


        public HttpResponse Register()
            => View();

        [HttpPost]
        public HttpResponse Register(RegisterViewModel model)
        {
            var (isValid, errors) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View();
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch(ArgumentException aex)
            {
                return View();
            }
            catch (Exception ex)
            {
                return View(
                    new List<ErrorViewModel>() { new ErrorViewModel("Unexpected register error") },
                    "/Error");
            }

            return Redirect("/Users/Login");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
