using System;

namespace Shirt
{
    class Program
    {
        static void Main(string[] args)
        {
            Bear gogiBear = new Bear();
            gogiBear.Age = 28;
            gogiBear.DaysSinceEaten = 5;
            gogiBear.Name = "gogi";

            Bear dimitrickoBear = new Bear();
            dimitrickoBear.Age = 30;
            dimitrickoBear.DaysSinceEaten = 3;
            dimitrickoBear.Name = "dimitricko";

            Bear poohBear = new Bear();
            poohBear.Age = 12;
            poohBear.DaysSinceEaten = 1;
            poohBear.Name = "pooh";

            Bear[] bearZoo = new Bear[3] { gogiBear, dimitrickoBear, poohBear };

            foreach (Bear bear in bearZoo)
            {
                if (bear.DaysSinceEaten >= 3)
                {
                    bear.Eat();
                }
            }

            //Shirt calvinShirt = new Shirt();

            //calvinShirt.Size = "XL";
            //calvinShirt.Quantity = 55;
            //calvinShirt.Price = 3;

            //calvinShirt.Wash();

        }
    }
}
