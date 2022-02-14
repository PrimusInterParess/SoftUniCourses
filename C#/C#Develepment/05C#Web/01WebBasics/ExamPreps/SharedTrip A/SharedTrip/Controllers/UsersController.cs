
using System.Collections.Generic;
using System.Linq;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Contracts;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Services;
using SharedTrip.Models.UsersFormModels;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Login()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginFormModel model)
        {
            HttpResponse responseToReturn = null;

            var hashedPassword = passwordHasher.HasPassword(model.Password);

            var user = GetUserFromDatabase(model, hashedPassword);

            if (user == null)
            {
                responseToReturn = View();
            }
            else
            {
                this.SignIn(user);

                responseToReturn = Redirect("/Trips/All");
            }

            return responseToReturn;
        }

        private string? GetUserFromDatabase(UserLoginFormModel model, string hashedPassword)
        {
            var user =
                data
                    .Users
                    .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                    .Select(u => u.Id)
                    .FirstOrDefault();
            return user;
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterFormModel model)
        {
            var result
                = validator.ValidateUserRegistrationFormModel(model);

            HttpResponse responseToReturn = null;

            if (result.isValid == false)
            {
                responseToReturn = View();
            }
            else
            {
                User user = CreateUser(model);

                AddUserToDatabase(user);

                responseToReturn = Redirect("/Users/Login");
            }

            return responseToReturn;
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }

        private void AddUserToDatabase(User user)
        {
            this.data.Users.Add(user);

           this.data.SaveChanges();
        }

        private User CreateUser(UserRegisterFormModel model)
        {
            return new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HasPassword(model.Password)
            };
        }

       
    }
}
