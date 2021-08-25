using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Eggs.Contracts;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private const int energyReducer = 10;
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidEggName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }
                else
                {
                    this.energyRequired = value;
                }
            }
        }
        public void GetColored()
        {
            this.EnergyRequired -= energyReducer;
        }

        public bool IsDone()
        {
            return this.EnergyRequired == 0;
        }
    }
}
