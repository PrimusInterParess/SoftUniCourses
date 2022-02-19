using Git.ViewModels.ErrorViewModel;
using Git.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Contracts
{
    public interface IUserService
    {
     //   (bool, ICollection<ErrorViewModel>) RegisterUser(UserRegisterViewModel model);
        bool LoginUser(UserLoginViewModel model);

        //User GetUserByUsername(string username);

        //User GetUserByUserId(string userId);

        //UserAuthenticatedViewModel GetIsAuthenticatedUserModel();
    }
}
