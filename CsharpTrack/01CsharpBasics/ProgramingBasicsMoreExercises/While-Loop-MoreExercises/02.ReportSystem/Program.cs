using System;

namespace _02.ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            double expectedIncome = double.Parse(Console.ReadLine());


            int transactionCounter = 0;
            double cash = 0;
            double creditCard = 0;
            double collectedCashMoney = 0;
            double collectedCreditCardMoney = 0;
            double summery = 0;
            bool collectedMoney = false;


            string command = Console.ReadLine();

            while (command != "End")
            {
                double productPrice = double.Parse(command);
                transactionCounter++;

                if (transactionCounter % 2 == 1)
                {
                    if (productPrice <= 100)
                    {
                        cash++;

                        collectedCashMoney += productPrice;
                        Console.WriteLine("Product sold!");

                    }
                    else
                    {
                        Console.WriteLine("Error in transaction!");

                    }
                }
                else
                {
                    if (productPrice > 100)
                    {
                        creditCard++;

                        collectedCreditCardMoney += productPrice;
                        Console.WriteLine("Product sold!");


                    }
                    else
                    {
                        Console.WriteLine("Error in transaction!");

                    }
                }

                summery = collectedCashMoney + collectedCreditCardMoney;

                if (summery >= expectedIncome)
                {
                    collectedMoney = true;
                    break;
                }

                command = Console.ReadLine();

            }

            if (collectedMoney)
            {
                double averageCS = collectedCashMoney / cash;
                double averageCC = collectedCreditCardMoney / creditCard;
                Console.WriteLine($"Average CS: {averageCS:f2}");
                Console.WriteLine($"Average CC: {averageCC:f2}");
            }
            else
            {
                Console.WriteLine("Failed to collect required money for charity.");

            }
        }
    }
}
