using System;

namespace _03.FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double availableMoney = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine()); //if age <19 = 20% discount
            string sport = Console.ReadLine();
            double price = 0;

            if (gender == "m")
            {
                if (sport == "Gym")
                {
                    price = 42;
                }
                else if (sport == "Boxing")
                {
                    price = 41;
                }
                else if (sport == "Yoga")
                {
                    price = 45;
                }
                else if (sport == "Zumba")
                {
                    price = 34;
                }
                else if (sport == "Dances")
                {
                    price = 51;
                }
                else if (sport == "Pilates")
                {
                    price = 39;
                }
            }
            else if (gender == "f")
            {
                if (sport == "Gym")
                {
                    price = 35;
                }
                else if (sport == "Boxing")
                {
                    price = 37;
                }
                else if (sport == "Yoga")
                {
                    price = 42;
                }
                else if (sport == "Zumba")
                {
                    price = 31;
                }
                else if (sport == "Dances")
                {
                    price = 53;
                }
                else if (sport == "Pilates")
                {
                    price = 37;
                }
            }
            if (age <= 19)
            {
                price -= price * 0.20;
            }
            if (availableMoney >= price)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                double neededMoney = price - availableMoney;
                Console.WriteLine($"You don't have enough money! You need ${neededMoney:f2} more.");
            }

        }
    }
    }
}
