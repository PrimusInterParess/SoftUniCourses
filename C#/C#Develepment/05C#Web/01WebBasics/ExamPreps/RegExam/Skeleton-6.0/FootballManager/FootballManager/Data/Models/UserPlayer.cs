namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserPlayer
    {
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
    }
}
