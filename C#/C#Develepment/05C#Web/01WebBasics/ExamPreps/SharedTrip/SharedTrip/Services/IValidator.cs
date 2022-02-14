using SharedTrip.Models;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        bool ValidateUserRegistration(RegisterUserFormModel model);
    }
}