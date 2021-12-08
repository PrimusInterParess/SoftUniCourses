using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {

        public Team()
        {
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
            this.Players = new List<Player>();
        }

        public int TeamId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2048)]
        public string LogoUrl { get; set; }

        [Required]
        [MaxLength(4)]
        [Column(TypeName = "char(3)")]
        public string Initials { get; set; }

        public decimal Budget { get; set; }


        public int PrimaryKitColorId { get; set; }

        [InverseProperty(nameof(Color.PrimaryKitTeams))]
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        [InverseProperty(nameof(Color.SecondaryKitTeams))]

        public Color SecondaryKitColor { get; set; }


        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Game> HomeGames { get; set; }

        public ICollection<Game> AwayGames { get; set; }

        public ICollection<Player> Players { get; set; }




    }
}
