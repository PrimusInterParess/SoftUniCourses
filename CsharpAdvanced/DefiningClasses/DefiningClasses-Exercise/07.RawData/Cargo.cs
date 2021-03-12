using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Cargo
    {
        private string cargoType;

        private double cargoWeight;

        public Cargo(double cargoWeight,string cargoType)
        {
            CargoType = cargoType;
            CargoWeight = cargoWeight;
        }

        public string CargoType
        {
            get => this.cargoType;
            set => this.cargoType = value;
        }

        public double CargoWeight
        {
            get => this.cargoWeight;
            set => this.cargoWeight = value;
        }


    }
}
