using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SharedTrip.Contracts;
using SharedTrip.Data;
using SharedTrip.Models.TripsFormModels;
using SharedTrip.Models.UsersFormModels;
using static SharedTrip.Constants.GlobalConstants;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public Validator(
            ApplicationDbContext data,
            IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
        }


        public (bool isValid, ICollection<string>) ValidateUserRegistrationFormModel(UserRegisterFormModel model)
        {
            bool isValid = true;

            ICollection<string> errorMessages = new List<string>();

            if (model.Username == null ||
                model.Username.Length <= MinUserNameLength ||
                model.Username.Length > DefaultMaxLength)
            {
                isValid = false;

                errorMessages.Add($"Username is invalid.Username length must be between {MinUserNameLength} and {DefaultMaxLength} char long.");
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;

                errorMessages.Add($"Cannot register user without email address");
            }

            if (string.IsNullOrWhiteSpace(model.Password) ||
                string.IsNullOrWhiteSpace(model.ConfirmPassword) ||
                model.Password != model.ConfirmPassword)
            {
                isValid = false;

                errorMessages.Add($"User confirmation password does not match.Try again!");
            }

            return (isValid, errorMessages);
        }

        public (bool isValid, ICollection<string>) ValidateTripAddFormModel(TripAddFormModel model)
        {
            bool isValid = true;

            ICollection<string> errorMessages = new List<string>();

            DateTime date;

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                isValid = false;

                errorMessages.Add("Field 'Departure Time' is invalid!");
            }
            
            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                isValid = false;

                errorMessages.Add("Field 'Start Point' is required!");
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                isValid = false;

                errorMessages.Add("Field 'End Point' is required!");
            }

            if (string.IsNullOrWhiteSpace(model.Description))
            {
                isValid = false;

                errorMessages.Add("Field 'Description' is required!");
            }

            if (model.Description.Length > DefaultStringMaxLength)
            {
                isValid = false;

                errorMessages.Add($"Field 'Description' must to be less or equal to {DefaultStringMaxLength} characters long!");
            }

            if (model.Seats < MinSeatsValue || model.Seats > MaxSeatsValue)
            {
                isValid = false;

                errorMessages.Add($"Seats needs to be between {MinSeatsValue} and {MaxSeatsValue}");
            }

            return (isValid, errorMessages);
        }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a StartPoint – a string (required)
//    •	Has a EndPoint – a string (required)
//    •	Has a DepartureTime – a datetime (required) 
//    •	Has a Seats – an integer with min value 2 and max value 6 (required)
//    •	Has a Description – a string with max length 80 (required)
//    •	Has a ImagePath – a string
//    •	Has UserTrips collection – a UserTrip type


