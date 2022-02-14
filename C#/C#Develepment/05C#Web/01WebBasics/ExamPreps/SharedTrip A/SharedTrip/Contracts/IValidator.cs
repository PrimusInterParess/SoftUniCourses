using System.Collections.Generic;
using SharedTrip.Models.TripsFormModels;
using SharedTrip.Models.UsersFormModels;

namespace SharedTrip.Contracts
{
    public interface IValidator
    {
        public (bool isValid, ICollection<string>) ValidateUserRegistrationFormModel(UserRegisterFormModel model);

        public (bool isValid, ICollection<string>) ValidateTripAddFormModel(TripAddFormModel model);
    }
}