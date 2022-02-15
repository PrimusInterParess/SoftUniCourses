using System.Collections.Generic;
using SharedTrip.Models;
using SharedTrip.Models.Users;

namespace SharedTrip.Contracts
{
    public interface IUserService
    {
        (bool isValid, ICollection<ErrorViewModel>) ValidateModel(RegisterViewModel model);
        void RegisterUser(RegisterViewModel model);
        (string, bool) IsLoginCorrect(LoginViewModel model);
    }
}