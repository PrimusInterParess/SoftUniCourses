using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Users;
using static SharedTrip.Constants.GlobalConstants;
namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public (bool isValid, ICollection<ErrorViewModel>) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;

            ICollection<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(model.Username) ||
               model.Username.Length < MinUserNameLength ||
               model.Username.Length > DefaultMaxLength)
            {
                isValid = false;

                errors.Add(
                    new ErrorViewModel($"Username is required and should be between {MinUserNameLength} and {DefaultMaxLength} characters long."));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;

                errors.Add(
                    new ErrorViewModel($"Email is required."));
            }

            if (string.IsNullOrWhiteSpace(model.Password) ||
                model.Password.Length < MinPasswordLength ||
                model.Password.Length > DefaultMaxLength)
            {
                isValid = false;

                errors.Add(
                    new ErrorViewModel($"Password is required and should be between {MinPasswordLength} and {DefaultMaxLength} characters"));
            }

            if (string.IsNullOrWhiteSpace(model.ConfirmPassword)
                || model.Password != model.ConfirmPassword)
            {
                isValid = false;

                errors.Add(
                    new ErrorViewModel($"Password and confirmed password are not the same."));
            }

            return (isValid, errors);
        }

        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = GetUserByUserName(model.Username);

            if (userExists != null)
            {
                throw new ArgumentException("User already exists");
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashingPassword(model.Password)
            };

            repo.Add(user);

            repo.SaveChanges();
        }

        public (string, bool) IsLoginCorrect(LoginViewModel model)
        {
            bool isCorrect = false;

            string userId = String.Empty;

            var user = GetUserByUserName(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == HashingPassword(model.Password);

                if (isCorrect)
                {
                    userId = user.Id;
                }
            }


            return (userId, isCorrect);

        }

        private User GetUserByUserName(string username)
        {
            return repo.All<User>().FirstOrDefault(u => u.Username == username);
        }

        private string HashingPassword(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
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