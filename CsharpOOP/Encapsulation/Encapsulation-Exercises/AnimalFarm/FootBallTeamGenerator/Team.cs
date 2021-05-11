using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootBallTeamGenerator
{
    public class Team
    {

        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new Dictionary<string, Player>();

        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfNameIsInvalid(value, GlobalConstants.InvalidExeptionMassege);

                this.name = value;
            }
        }

        public double GetAveragePoints
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return Math.Round(this.players.Values.Average(p => p.AverageStats));
            }

        }

        public void RemovePlayer(string playerName)
        {
            if (!players.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(playerName);
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player.Name, player);
        }
    }
}
