using System;

namespace _04.CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            int ticketCounter = 0;
            int products = 0;
            while (true)
            {
                string purchaseName = Console.ReadLine();

                if (purchaseName == "End")
                {
                    break;
                }

                int digitsSum = 0;


                if (purchaseName.Length > 8)
                {
                    digitsSum = purchaseName[0] + purchaseName[1];

                    if (digitsSum <= sum)
                    {
                        ticketCounter++;
                    }
                }
                else if (purchaseName.Length <= 8)
                {
                    digitsSum += purchaseName[0];

                    if (digitsSum <= sum)
                    {
                        products++;
                    }
                }

                if (digitsSum > sum)
                {
                    break;
                }

                sum -= digitsSum;


            }
            Console.WriteLine($"{ticketCounter}");
            Console.WriteLine($"{products}");
        }
    }
}
