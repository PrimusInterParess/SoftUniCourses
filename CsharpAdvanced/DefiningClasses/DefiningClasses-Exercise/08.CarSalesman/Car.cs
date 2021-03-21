using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {

        private string model;

        private int? weight; 

        private string color; 


        public Car(string model, Engine engine)
      
        {
            Model = model;
            Engine = engine;
            

        }

        public Car(string model, Engine engine, int weight)
        : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color )
            : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }


        public Engine Engine { get; set; }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int? Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public string Color
        {
            get => this.color;
            set => this.color = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string weightStr = this.Weight.HasValue ? this.Weight.ToString() : "n/a";

            string colorStr = string.IsNullOrEmpty(this.Color) ? "n/a" : this.Color;

            sb.AppendLine($"{this.Model}:")
                .AppendLine($"{this.Engine}")
                .AppendLine($"  Weight: {weightStr}")
                .AppendLine($"  Color: {colorStr}");

            return sb.ToString().TrimEnd();

        }
    }
}
