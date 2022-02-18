using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SharedTrip.Constants.GlobalConstants;
namespace SharedTrip.Models.Users
{
    public class UserLoginViewModel
    {
        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }
    }
}
