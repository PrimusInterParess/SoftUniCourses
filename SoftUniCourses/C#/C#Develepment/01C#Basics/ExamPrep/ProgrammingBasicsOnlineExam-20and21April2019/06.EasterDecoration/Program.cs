using System;

namespace _06.EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int customersNumber = int.Parse(Console.ReadLine());
            int totalProducts = 0;
            double totalSum = 0;

            for (int i = 0; i < customersNumber; i++)
            {
                string products = Console.ReadLine();
                double price = 0;
                int productCounter = 0;

                while (products != "Finish")
                {
                    productCounter++;

                    switch (products)
                    {
                        case "basket":
                            price += 1.50; totalProducts++;
                            break;
                        case "wreath":
                            price += 3.80; totalProducts++;
                            break;
                        case "chocolate bunny":
                            price += 7; totalProducts++;
                            break;
                    }

                    products = Console.ReadLine();
                }

                if (productCounter % 2 == 0)
                {
                    price *= 0.80;
                }

                totalSum += price;

                Console.WriteLine($"You purchased {productCounter} items for {price:F2} leva.");
            }
            double average = totalSum / customersNumber;

            Console.WriteLine($"Average bill per client is: {average:F2} leva.");
        }
    }
}
