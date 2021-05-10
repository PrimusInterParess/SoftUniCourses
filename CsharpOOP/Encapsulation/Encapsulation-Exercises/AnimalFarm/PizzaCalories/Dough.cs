using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinDoughWeight = 1;
        private const int MaxDoughWeigh = 200;
        private const string InvalidDough = "Invalid type of dough.";

        private string flourType;
        private string doughType;
        private double weight;

        public Dough(string flourType, string doughType, double weight)
        {
            this.FlourType = flourType;
            this.DoughType = doughType;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                Validator.ThrowIfFlourTypeIsInvalid(value, InvalidDough);

                this.flourType = value;
            }
        }

        public string DoughType
        {
            get => this.doughType;
            private set
            {
                Validator.ThrowIfFlourTypeIsInvalid(value, InvalidDough);

                this.doughType = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfWeightIsOutSideBounds
                    (MinDoughWeight,
                    MaxDoughWeigh,
                    value,
                    $"Dough weight should be in the range [{MinDoughWeight}..{MaxDoughWeigh}].");

                this.weight = value;
            }
        }

        public double CalculatingCalories()
        {
            var flourModifier = GetModifier(this.flourType);

            var doughModifier = GetModifier(this.doughType);

            return 2 * this.Weight * flourModifier * doughModifier;
        }

        private double GetModifier(string amodifier)
        {
            var modifier = amodifier.ToLower();
            if (modifier == "white")
            {
                return 1.5;
            }

            if (modifier == "wholegrain")
            {
                return 1.0;
            }

            if (modifier == "crispy")
            {
                return 0.9;

            }

            if (modifier == "chewy")
            {
                return 1.1;
            }

            return 1.0;

        }
    }
}
