using System.Collections.Generic;
using SMS.Models;
using SMS.Models.Users;

namespace SMS.Contracts;

public interface IUserService
{
    (bool isValid, string errors) Register(UserRegisterViewModel model);

    string Login(UserLoginViewModel model);

    string GetUserName(string userId);
}