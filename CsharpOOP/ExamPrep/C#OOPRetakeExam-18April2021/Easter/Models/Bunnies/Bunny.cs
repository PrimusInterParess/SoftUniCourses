using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private const int reducingEnergy = 10;

        private string name;
        private int energy;
        

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Dyes = new List<IDye>();
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set { this.energy = value < 0 ? 0 : value; }
        }

        public ICollection<IDye> Dyes
        {
            get;
        }

        public virtual void Work()
        {
            this.Energy -= reducingEnergy;
        }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }
    }
}
