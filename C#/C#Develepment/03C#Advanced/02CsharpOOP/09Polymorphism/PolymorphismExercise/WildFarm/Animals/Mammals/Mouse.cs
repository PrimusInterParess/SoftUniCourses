using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
  public  class Mouse:Mammal
    {
        private const double FOOD_MODIFIER = 0.10;

        private static HashSet<string> AllowedFoods = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Fruit)
        };


        public Mouse(
            string name,
            double weight,
            string livingRegion)
            : base(name, weight, AllowedFoods, FOOD_MODIFIER, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
