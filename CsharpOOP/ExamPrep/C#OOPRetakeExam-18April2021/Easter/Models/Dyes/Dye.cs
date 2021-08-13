using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private const int powerReducer = 10;
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get => this.power;
            protected set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                else
                {
                    this.power = value;
                }

            }
        }
        public void Use()
        {
            this.Power -= powerReducer;
        }

        public bool IsFinished()
        {
            return this.Power == 0;
        }
    }
}
