using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        private double Comp_Multiplier { get; set; }

        private int generation;
        private double overallPerformance;

        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation, double compMultiplier)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
            this.Comp_Multiplier = compMultiplier;
            this.OverallPerformance = overallPerformance;

        }

        public int Generation
        {
            get => this.generation;
            private set => this.generation = value;
        }

        public override double OverallPerformance
        {
            get => this.overallPerformance;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Overall Performance can not be less or equal than 0.");
                }

                this.overallPerformance = value *= Comp_Multiplier;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} + Generation: {this.Generation}";
        }


    }
}
