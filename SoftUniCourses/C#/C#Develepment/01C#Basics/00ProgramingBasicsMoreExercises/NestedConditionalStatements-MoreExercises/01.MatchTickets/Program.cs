using System;

namespace _01.MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int numberOfPeople = int.Parse(Console.ReadLine());

            double transportExpences = 0;
            double ticketCost = 0;

            if (category == "VIP")
            {
                ticketCost = numberOfPeople * 499.99;
            }
            else
            {
                ticketCost = numberOfPeople * 249.99;
            }

            if (numberOfPeople >= 1 && numberOfPeople <= 4)
            {
                transportExpences = budget * 0.75;
            }
            else if (numberOfPeople >= 5 && numberOfPeople <= 9)
            {
                transportExpences = budget * 0.60;
            }
            else if (numberOfPeople >= 10 && numberOfPeople <= 24)
            {
                transportExpences = budget * 0.50;
            }
            else if (numberOfPeople >= 25 && numberOfPeople <= 49)
            {
                transportExpences = budget * 0.40;
            }
            else
            {
                transportExpences = budget * 0.25;
            }

            double totalExpences = ticketCost + transportExpences;
            if (budget > totalExpences)
            {
                double moneyLeft = budget - totalExpences;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                double neededMoney = totalExpences - budget;
                Console.WriteLine($"Not enough money! You need {neededMoney:f2} leva.");
            }
        }
    }
}
