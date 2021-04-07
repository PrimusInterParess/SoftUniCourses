using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Guild
{
    class Player
    {
        private string name;

        private string Class;

        private string rank;

        private string description;


        public Player(string name,string rank)
        {
            this.name = name;
            this.rank = rank;
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {this.name}");
            sb.AppendLine($"Rank: {this.rank}");
            sb.AppendLine($"Description: {this.");
        }
    }
}
