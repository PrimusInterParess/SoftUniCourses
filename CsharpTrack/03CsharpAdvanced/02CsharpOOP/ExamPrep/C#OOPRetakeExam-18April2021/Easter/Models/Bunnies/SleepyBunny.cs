using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int energy = 50;
        private const int additionalEnergyReducer = 5;

        public SleepyBunny(string name) : base(name, energy)
        {
        }

        public override void Work()
        {
            base.Work();
            this.Energy -= additionalEnergyReducer;
        }
    }
}
