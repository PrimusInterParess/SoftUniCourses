using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> carList = new List<Car>();

            Predicate<string> carExistnace;

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carData[0];

                double fuelAmount = double.Parse(carData[1]);

                double fuelConsumptionFor1km = double.Parse(carData[2]);

                if (CarExistance(model, carList))
                {
                    carList.Add(new Car(model, fuelAmount, fuelConsumptionFor1km));
                }

            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] actonStrings = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carModel = actonStrings[1];

                double distance = double.Parse(actonStrings[2]);

                foreach (var car in carList)
                {
                    if (car.Model == carModel)
                    {
                        if (!car.Drive(distance))
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                    }
                }
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }

        static bool CarExistance(string modelToCheck, List<Car> carList)
        {

            foreach (var car in carList)
            {
                if (car.Model == modelToCheck)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
