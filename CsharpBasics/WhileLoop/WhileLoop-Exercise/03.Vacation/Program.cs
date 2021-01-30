using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double holliDayCost = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int dayCounter = 0;
            int daysSpend = 0;


            while (true)
            {
                string action = Console.ReadLine();
                double currentMoney = double.Parse(Console.ReadLine());
                dayCounter++;

                if (action == "spend")
                {
                    daysSpend++;
                    availableMoney -= currentMoney;

                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }

                    if (daysSpend == 5)
                    {
                        Console.WriteLine($"You can't save the money.\r\n{dayCounter}");
                        break;
                    }
                }
                else if (action == "save")
                {
                    availableMoney += currentMoney;
                    daysSpend = 0;
                }

                if (availableMoney >= holliDayCost)
                {
                    Console.WriteLine($"You saved the money for {dayCounter} days.");
                    break;
                }
            }
        }
    }
}
