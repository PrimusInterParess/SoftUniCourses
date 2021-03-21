using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        private string model;

        private int power;

        private int? displacment;

        private string efficiency;

       

        public Engine(string model, int power)
        
        {
            Model = model;
            Power = power;
            

        }

        public Engine(string model, int power, int displacment)
        : this(model, power)
        {
            Displacment = displacment;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacment, string efficiency)
            : this(model, power)
        {

            Displacment = displacment;
            Efficiency = efficiency;
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

        public int? Displacment
        {
            get => this.displacment;
            set => this.displacment = value;
        }

        public string Efficiency
        {
            get => this.efficiency; set =>
                  this.efficiency = value;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string displacementStr = this.Displacment.HasValue ? this.Displacment.ToString() : "n/a";

            string efficiencyStr = string.IsNullOrEmpty(this.Efficiency) ? "n/a" : this.Efficiency;

            sb
                .AppendLine($"  {this.Model}:")
                .AppendLine($"    Power: {this.Power}")
                .AppendLine($"    Displacement: {displacementStr}")
                .AppendLine($"    Efficiency: {efficiencyStr}");

            return sb.ToString().TrimEnd();
        }
    }
}
