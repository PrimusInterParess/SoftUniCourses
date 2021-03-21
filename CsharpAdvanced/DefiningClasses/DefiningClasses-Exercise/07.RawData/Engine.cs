using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Engine
    {
        private double horsePower;

        private double speedEngine;

        public Engine(double speedEngine, double horsePower)
        {
            SpeedEngine = speedEngine;
            HorsePower = horsePower;
        }

        public double HorsePower
        {
            get => this.horsePower;
            set => this.horsePower = value;
        }

        public double SpeedEngine
        {
            get => this.speedEngine;
            set => this.speedEngine = value;
        }

    }
}
