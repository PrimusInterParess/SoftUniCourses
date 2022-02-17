using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models.Users;

namespace SMS.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepository repo;

        private readonly IValidationService validation;
        public UserService(IRepository repo,
            IValidationService validation)
        {
            this.repo = repo;
            this.validation = validation;
        }
        

        public (bool isValid, string errors) Register(UserRegisterViewModel model)
        {
            bool registered = false;

            string error = null;

            var (isValid, errors) = this.validation.ValidateModel(model);

            if (isValid==false)
            {
                return (isValid, errors);
            }

            Cart cart = new Cart();

            User user = new User()
            {
                Email = model.Email,
                Username = model.Username,
                Password = HashingPassword(model.Password),
                Cart = cart,
                CartId = cart.Id
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();

                registered = true;

            }
            catch (Exception)
            {
                error = "Could not save User";
            }

            return (registered, error);
        }


     

        public string Login(UserLoginViewModel model)
        {
            var user = repo
                .All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u=>u.Password==HashingPassword(model.Password)).SingleOrDefault();

            return user?.Id;
        }

        public string GetUserName(string userId)
        {
            return repo.All<User>().FirstOrDefault(u => u.Id == userId)?.Username;
        }

        private (bool isValid, string errors) ValidateUserRegisterModel(UserRegisterViewModel model)
        {
            bool isValid = true;

            var errors = new StringBuilder();

            if (model == null)
            {
                return (false, "Register form is Required!");
            }


            return (isValid, errors.ToString());
        }

   



        private string HashingPassword(string rawData)
        {
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
