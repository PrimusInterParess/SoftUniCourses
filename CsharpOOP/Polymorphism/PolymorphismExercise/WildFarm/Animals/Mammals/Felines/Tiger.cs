using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double FOOD_MODIFIER = 1.0;

        private static HashSet<string> AllowedFoods = new HashSet<string>()
        {
            nameof(Meat)

        };

        public Tiger(
            string name,
            double weight,
            string livingRegion,
            string breed) 
            : base(name, weight, AllowedFoods, FOOD_MODIFIER, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
