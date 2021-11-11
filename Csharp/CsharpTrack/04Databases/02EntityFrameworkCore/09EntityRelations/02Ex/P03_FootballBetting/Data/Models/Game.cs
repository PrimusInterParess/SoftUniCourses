using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {

        public Game()
        {
            this.Bets = new List<Bet>();
            this.PlayerStatistics = new List<PlayerStatistic>();
        }

        //•	Game – GameId, HomeTeamId, AwayTeamId, HomeTeamGoals,
        //AwayTeamGoals, DateTime, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result)

        public int GameId { get; set; }

        public int HomeTeamId { get; set; }

        [InverseProperty(nameof(Team.HomeGames))]
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [InverseProperty(nameof(Team.AwayGames))]
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        [Required]
        public string Result { get; set; }

        public ICollection<Bet> Bets { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }


    }
}
