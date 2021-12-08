using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;


        public Guild(string name, int capacity)
        {

            Name = name;
            Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> playersToReturn = new List<Player>();

            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Class == @class)
                {
                    playersToReturn.Add(roster[i]);

                    roster.Remove(roster[i]);
                }
            }

          

            return playersToReturn.ToArray();
        }

        public int Count => this.roster.Count;

        public void DemotePlayer(string name)
        {
            Player player = ReturnsNeededPlayer(name);

            if (player == null)
            {
                return;
            }

            Demototing(player);
        }

        public void AddPlayer(Player player)
        {
            var occupation = this.roster.Count;

            bool available = ChecksCapacity(occupation, Capacity);

            if (available)
            {
                this.roster.Add(player);
            }
        }

        public void PromotePlayer(string name)
        {
            Player toPromotote = ReturnsNeededPlayer(name);

            if (toPromotote == null)
            {
                return;
            }

            Promoting(toPromotote);
        }


        public bool RemovePlayer(string name)
        {
            Player player = ReturnsNeededPlayer(name);

            if (player == null)
            {
                return false;
            }

            roster.Remove(player);

            return true;

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();

        }

        private Player ReturnsNeededPlayer(string name)
        {
            Player toReturn = null;

            foreach (var player in this.roster)
            {
                if (player.Name == name)
                {
                    toReturn = player;
                    break;
                }
            }

            return toReturn;
        }

        private bool ChecksCapacity(int occupation, int capacity)
        {
            if (occupation < capacity)
            {
                return true;
            }

            return false;
        }

        private void Promoting(Player toPromotote)
        {
            if (toPromotote.Rank != "Member")
            {
                toPromotote.Rank = "Member";
            }
        }

        private void Demototing(Player player)
        {
            if (player.Rank != "Trail")
            {
                player.Rank = "Trail";
            }
        }

    }
}