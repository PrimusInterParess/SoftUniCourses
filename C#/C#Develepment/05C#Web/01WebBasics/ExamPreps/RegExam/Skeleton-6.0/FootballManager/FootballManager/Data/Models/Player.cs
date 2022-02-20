namespace FootballManager.Data.Models
{

    using static Constants.IntegerConstants;
    using System.ComponentModel.DataAnnotations;


    public class Player
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(PlayerNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Position { get; set; }

        [Required]
        [MaxLength(SpeedEnduranceMaxLength)]
        public byte Speed { get; set; }

        [Required]
        [MaxLength(SpeedEnduranceMaxLength)]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new HashSet<UserPlayer>();
    }
}
