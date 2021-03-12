using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        private string model;

        private int power;

        private int displacment;

        private string efficiency;


        public Engine(string model, int power)

        {
            Model = model;
            Power = power;
            Displacment = 0;
            Efficiency = "";

        }

        public Engine(string model, int power, int displacment)
        : this(model, power)
        {
            Displacment = displacment;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            Efficiency = Efficiency;
        }

        public Engine(string model, int power, int displacment, string efficiency)
            : this(model, power)
        {

            Displacment = displacment;
            Efficiency = Efficiency;
        }


        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Power
        {
            get => this.power;
            set => this.power = value;
        }

        public int Displacment
        {
            get => this.displacment;
            set => this.displacment = value;
        }

        public string Efficiency
        {
            get => this.efficiency; set =>
                  this.efficiency = value;
        }

    }
}
