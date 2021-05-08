using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                Validator.ThrowIfNumberIsNegative(value, $"Money cannot be negative");

                this.cost = value;
            }


        }

        public string Name
        {
            get => this.name;
            set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, $"Name cannot be empty");

                this.name = value;
            }
        }
    }
}
