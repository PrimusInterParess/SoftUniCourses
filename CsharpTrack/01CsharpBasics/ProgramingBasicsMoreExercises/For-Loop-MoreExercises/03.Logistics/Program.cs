using System;

namespace _03.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLoads = int.Parse(Console.ReadLine());

            double bussWeightSum = 0;
            double truckWeightSum = 0;
            double trainWeightSum = 0;

            for (int i = 1; i <= numLoads; i++)
            {
                double weight = double.Parse(Console.ReadLine());

                if (weight <= 3)
                {
                    bussWeightSum += weight;
                }
                else if (weight > 3 && weight <= 11)
                {
                    truckWeightSum += weight;
                }
                else
                {
                    trainWeightSum += weight;
                }

            }
            double totalWeight = bussWeightSum + truckWeightSum + trainWeightSum;
            double averagePrice = ((bussWeightSum * 200) + (truckWeightSum * 175) + (trainWeightSum * 120)) / totalWeight;
            double bussWeightPercentage = (bussWeightSum / totalWeight) * 100;
            double truckWeightPercentage = (truckWeightSum / totalWeight) * 100;
            double trainWeightPercentage = (trainWeightSum / totalWeight) * 100;

            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{bussWeightPercentage:f2}%");
            Console.WriteLine($"{truckWeightPercentage:f2}%");
            Console.WriteLine($"{trainWeightPercentage:f2}%");
        }
    }
}
