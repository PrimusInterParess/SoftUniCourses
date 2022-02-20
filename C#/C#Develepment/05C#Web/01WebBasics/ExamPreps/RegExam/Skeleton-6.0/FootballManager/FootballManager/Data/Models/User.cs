namespace FootballManager.Data.Models
{
    using static Constants.IntegerConstants;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(DefaultStringMaxLength)]
        public string Email { get; set; }

        [Required]
       
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new HashSet<UserPlayer>();

    }
}
