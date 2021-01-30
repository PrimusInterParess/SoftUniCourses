using System;

namespace _03.Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemum = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulip = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string typeOfDay = Console.ReadLine();

            double chrysanthemumPrice = 0;
            double rosesPrice = 0;
            double tulipPrice = 0;
            double bouquet = 0;
            double sumFlowers = 0;
            double finalprice = 0;

            if (season == "Spring" || season == "Summer")
            {

                chrysanthemumPrice = chrysanthemum * 2;
                rosesPrice = roses * 4.10;
                tulipPrice = tulip * 2.50;
                bouquet = chrysanthemumPrice + rosesPrice + tulipPrice;
                if (typeOfDay == "Y")
                {
                    bouquet *= 1.15;
                }

                if (season == "Spring" && tulip > 7)
                {
                    bouquet -= bouquet * 0.05;
                }
                sumFlowers = chrysanthemum + roses + tulip;
                if (sumFlowers > 20)
                {
                    bouquet -= bouquet * 0.20;
                }
            }
            else
            {
                chrysanthemumPrice = chrysanthemum * 3.75;
                rosesPrice = roses * 4.50;
                tulipPrice = tulip * 4.15;
                bouquet = chrysanthemumPrice + rosesPrice + tulipPrice;
                if (typeOfDay == "Y")
                {
                    bouquet *= 1.15;
                }

                if (season == "Winter" && roses >= 10)
                {
                    bouquet -= bouquet * 0.1;
                }
                sumFlowers = chrysanthemum + roses + tulip;
                if (sumFlowers > 20)
                {
                    bouquet -= bouquet * 0.20;
                }
            }
            finalprice = bouquet + 2;
            Console.WriteLine($"{finalprice:f2}");
        }
    }
}
