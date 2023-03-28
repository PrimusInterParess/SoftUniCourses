using Git.Contracts;
using Git.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public class UserService : IUserService
    {

        private readonly IValidationService validationService;

        public UserService(IValidationService validationService)
        {
            this.validationService = validationService;
        }

        public bool LoginUser(UserLoginViewModel model)
        {
            var (isValid,errors) = validationService.ValidateModel(model);

            if (isValid==false)
            {
                return false;
            }
            
        }
    }
}
