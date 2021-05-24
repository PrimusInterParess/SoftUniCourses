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

        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, double generation, double compMultiplier)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = this.generation;
            this.Comp_Multiplier = compMultiplier;
            overallPerformance *= Comp_Multiplier;

        }

        public int Generation
        {
            get => this.generation;
            private set => this.generation = value;
        }

        public override string ToString()
        {
            return $"{base.ToString()} + Generation: {this.Generation}";
        }


    }
}
