using System.Collections.Generic;

namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {



        protected Bird(string name,
            double weight,
            HashSet<string> allowedFoods,
            double foodModifier, double wingSize)
            : base(name, weight, allowedFoods, foodModifier)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}