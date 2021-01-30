using System;

namespace _12.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double volumeSales = double.Parse(Console.ReadLine());
            double commitionPercentage = 0.0;



            if (town == "Sofia")
            {
                if (volumeSales >= 0 && volumeSales <= 500)
                {
                    commitionPercentage = 5;
                }
                else if (volumeSales > 500 && volumeSales <= 1000)
                {
                    commitionPercentage = 7;
                }
                else if (volumeSales > 1000 && volumeSales <= 10000)
                {
                    commitionPercentage = 8;
                }
                else if (volumeSales > 10000)
                {
                    commitionPercentage = 12;
                }
                else if (volumeSales <= 0)
                {
                    Console.WriteLine("error");
                }
                else
                {
                    Console.WriteLine("error");
                }
                double totalCommition = volumeSales * commitionPercentage / 100;
                Console.WriteLine($"{totalCommition:f2}");

            }

            else if (town == "Varna")
            {
                if (volumeSales >= 0 && volumeSales <= 500)
                {
                    commitionPercentage = 4.5;
                }
                else if (volumeSales > 500 && volumeSales <= 1000)
                {
                    commitionPercentage = 7.5;
                }
                else if (volumeSales > 1000 && volumeSales <= 10000)
                {
                    commitionPercentage = 10;
                }
                else if (volumeSales > 10000)
                {
                    commitionPercentage = 13;
                }
                else if (volumeSales <= 0)
                {
                    Console.WriteLine("error");
                }
                else
                {
                    Console.WriteLine("error");
                }
                double totalCommition = volumeSales * commitionPercentage / 100;
                Console.WriteLine($"{totalCommition:f2}");
            }
            else if (town == "Plovdiv")
            {
                if (volumeSales >= 0 && volumeSales <= 500)
                {
                    commitionPercentage = 5.5;
                }
                else if (volumeSales > 500 && volumeSales <= 1000)
                {
                    commitionPercentage = 8;
                }
                else if (volumeSales > 1000 && volumeSales <= 10000)
                {
                    commitionPercentage = 12;
                }
                else if (volumeSales > 10000)
                {
                    commitionPercentage = 14.5;
                }

                else
                {
                    Console.WriteLine("error");
                }
                double totalCommition = volumeSales * commitionPercentage / 100;
                Console.WriteLine($"{totalCommition:f2}");
            }
            else
            {

                Console.WriteLine("error");
            }

        }
    }
}
