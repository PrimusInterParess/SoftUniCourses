using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinNameLenght = 1;
        private const int MaxNameLenght = 15;
        private const int MinNumbToppings = 0;
        private const int MaxNumbToppings = 10;

        private string name;

        private Dough dough;

        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfPizzaNameIsInvalid(MinNameLenght, MaxNameLenght, value);

                this.name = value;
            }
        }

       

        public void AddToppings(Topping topping)
        {
            if (this.toppings.Count == MaxNumbToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MinNumbToppings}..{MaxNumbToppings}].");
            }

            toppings.Add(topping);
        }

        public double CalculatingCalories()
        {
            return this.dough.CalculatingCalories() + this.toppings.Sum(t => t.CalculatingCalories());
        }
    }
}
