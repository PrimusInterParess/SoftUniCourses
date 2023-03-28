namespace Git.ViewModels.UserViewModel
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.IntegerConstants;
    public class UserLoginViewModel
    {
        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }
    }
}
