namespace FootballManager.ViewModels.Users;

using static Constants.IntegerConstants;
using System.ComponentModel.DataAnnotations;

public class UserRegisterFormModel
{
    [Required]
    [StringLength(DefaultMaxLength, MinimumLength = MinLength,
        ErrorMessage = "{0} must be between {2} and {1} characters")]
    public string Username { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
    public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword should be the same")]
    public string ConfirmPassword { get; set; }
}