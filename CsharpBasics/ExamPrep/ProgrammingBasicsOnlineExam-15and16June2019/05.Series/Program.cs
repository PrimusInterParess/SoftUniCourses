using System;

namespace _05.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int showsNumber = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 0; i < showsNumber; i++)
            {
                string showName = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                switch (showName)
                {
                    case "Thrones":
                        price *= 0.50;
                        break;
                    case "Lucifer":
                        price *= 0.60;
                        break;
                    case "Protector":
                        price *= 0.70;
                        break;
                    case "TotalDrama":
                        price *= 0.80;
                        break;
                    case "Area":
                        price *= 0.90;
                        break;
                }

                sum += price;
            }

            if (budget >= sum)
            {
                double left = budget - sum;
                Console.WriteLine($"You bought all the series and left with {left:f2} lv.");
            }
            else
            {
                double need = sum - budget;
                Console.WriteLine($"You need {Math.Abs(need):F2} lv. more to buy the series!");
            }
        }
    }
}
