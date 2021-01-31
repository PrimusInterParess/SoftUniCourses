using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double price = 0;
            double total = 0;

            while (budget != 0)
            {
                string gamesName = Console.ReadLine();
                if (gamesName == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${total:F2}. Remaining: ${budget:f2}");
                    break;
                }

                switch (gamesName)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        continue;

                }
                if (budget >= price)
                {
                    total += price;
                    budget -= price;
                    Console.WriteLine($"Bought {gamesName}");

                }
                else
                {
                    Console.WriteLine("Too Expensive");

                }



            }
            if (budget <= 0)
            {
                Console.WriteLine("Out of money!");
            }
        }
    }
}
