namespace FootballManager.Contracts;

using ViewModels.Users;

public interface IUserService
{
    (bool, ICollection<string>) RegisterUser(UserRegisterFormModel model);
    string LoginUser(UserLoginFormModel model);


}