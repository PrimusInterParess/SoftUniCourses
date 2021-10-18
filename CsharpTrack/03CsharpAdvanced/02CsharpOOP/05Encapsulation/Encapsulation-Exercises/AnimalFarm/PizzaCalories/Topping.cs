using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string name;

        private double weight;

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {


                Validator.TrowIfToppingIsInvalid(value, $"Cannot place {value} on top of your pizza.");

                this.name = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfWeightIsOutSideBounds(
                    MinWeight,
                    MaxWeight,
                    value, $"{this.name} weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }

        public double CalculatingCalories()
        {
            var modifier = GetModifier(this.name);

            return this.Weight * 2 * modifier;
        }

        private double GetModifier(string amodifier)
        {
            var modifier = amodifier.ToLower();

            if (modifier == "meat")
            {
                return 1.2;
            }

            if (modifier == "veggies")
            {
                return 0.8;
            }

            if (modifier == "cheese")
            {
                return 1.1;
            }

            return 0.9;

        }
    }
}
