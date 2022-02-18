namespace SharedTrip.Models.Users
{

    using System.ComponentModel.DataAnnotations;
    using static Constants.GlobalConstants;

    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(DefaultMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword should be the same")]
        public string ConfirmPassword { get; set; }
    }
}
