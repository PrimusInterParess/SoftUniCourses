using System;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string device = Console.ReadLine();
            double points = 0;

            switch (country)
            {
                case "Russia":
                    switch (device)
                    {
                        case "ribbon":
                            points += 9.100 + 9.400;
                            break;
                        case "hoop":
                            points += 9.300 + 9.800;
                            break;
                        case "rope":
                            points += 9.600 + 9.000;
                            break;

                    }
                    break;
                case "Bulgaria":
                    switch (device)
                    {
                        case "ribbon":
                            points += 9.600 + 9.400;
                            break;
                        case "hoop":
                            points += 9.550 + 9.750;
                            break;
                        case "rope":
                            points += 9.500 + 9.400;
                            break;

                    }
                    break;
                case "Italy":
                    switch (device)
                    {
                        case "ribbon":
                            points += 9.200 + 9.500;
                            break;
                        case "hoop":
                            points += 9.450 + 9.350;
                            break;
                        case "rope":
                            points += 9.700 + 9.150;
                            break;

                    }
                    break;
            }

            double total = 20 - points;
            double leftPercentage = (total / 20) * 100;

            Console.WriteLine($"The team of {country} get {points:f3} on {device}.");
            Console.WriteLine($"{leftPercentage:f2}%");
        }
    }
}
