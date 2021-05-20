using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {

        private double FoodModifier { get; set; }

        private HashSet<string> allowedFoods { get; set; }

        protected int FoodEaten;


        protected Animal(string name,
            double weight,
            HashSet<string> allowedFoods,
            double foodModifier
            )
        {
            Name = name;
            Weight = weight;
            FoodModifier = foodModifier;
            this.allowedFoods = allowedFoods;


        }


        public string Name { get; private set; }

        public double Weight { get; private set; }



        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            string checkfood = food.GetType().Name;


            if (!allowedFoods.Contains(checkfood))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {checkfood}!");
            }

            FoodEaten = food.Quantity;


            this.Weight += this.FoodModifier * food.Quantity;
        }


    }
}