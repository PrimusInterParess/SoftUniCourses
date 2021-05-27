using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        private const string rank = "Trail";
        private const string description = "n/a";

        public Player(string name, string @class)
        {
            this.Name = name;
            this.Class = @class;
            this.Rank = rank;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank {Rank}");
            sb.AppendLine($"Description {Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
