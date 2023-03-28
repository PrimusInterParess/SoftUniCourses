namespace FootballManager.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.IntegerConstants;
    public class UserLoginFormModel
    {
        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = MinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }
    }
}
