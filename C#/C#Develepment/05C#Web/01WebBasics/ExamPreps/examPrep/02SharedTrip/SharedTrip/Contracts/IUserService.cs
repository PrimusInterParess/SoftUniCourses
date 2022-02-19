using System.Collections.Generic;
using SharedTrip.Data.Models;
using SharedTrip.Models.ErrorViewModels;
using SharedTrip.Models.Users;

namespace SharedTrip.Contracts;

public interface IUserService
{
    (bool, ICollection<ErrorViewModel>) RegisterUser(UserRegisterViewModel model);
    string LoginUser(UserLoginViewModel model);

    User GetUserByUsername(string username);

    User GetUserByUserId(string userId);

    UserAuthenticatedViewModel GetIsAuthenticatedUserModel();
}