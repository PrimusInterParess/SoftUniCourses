using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(
            string name,
            double weight,
            HashSet<string> allowedFoods,
            double foodModifier, string livingRegion)
            : base(name, weight, allowedFoods, foodModifier)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]";
        }
    }
}
