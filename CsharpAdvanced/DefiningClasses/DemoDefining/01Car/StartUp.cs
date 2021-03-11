using System;
using System.Collections.Generic;
using System.Linq;
using CarManufacturer;

namespace _01Car
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int carCount = 0;

            int tireIndex = 0;

            Dictionary<int, Tire[]> tiresMap = new Dictionary<int, Tire[]>();

            Dictionary<int, Engine> engines = new Dictionary<int, Engine>();

            string input = string.Empty;

            List<Car> cars = new List<Car>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireStrings = input.Split(' ').ToArray();

                Tire[] tires = new Tire[tireStrings.Length / 2];

                int tirecounter = 0;

                for (int i = 0; i < tireStrings.Length - 1; i += 2)
                {
                    int year = int.Parse(tireStrings[i]);

                    double pressure = double.Parse(tireStrings[i + 1]);

                    tires[tirecounter] = new Tire(year, pressure);

                    tirecounter++;

                }

                tiresMap[tireIndex] = tires;
                tireIndex++;

            }

            int engineIndex = 0;

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split().ToArray();

                int horsePower = int.Parse(engineInfo[0]);

                double cubicCapacity = double.Parse(engineInfo[1]);

                engines[engineIndex] = new Engine(horsePower, cubicCapacity);

                engineIndex++;

            }


            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carData = input.Split().ToArray();

                string make = carData[0];

                string model = carData[1];

                int year = int.Parse(carData[2]);

                double fuelQuantity = double.Parse(carData[3]);

                double fuelCapacity = double.Parse(carData[4]);

                int engIndex = int.Parse(carData[5]);

                Engine engine = engines[engIndex];

                int trIndex = int.Parse(carData[6]);

                List<Tire> tires = tiresMap[trIndex].ToList();

                cars.Add(new Car(make, model, year, fuelQuantity, fuelCapacity, engine, tires));
            }


            foreach (var car in cars)
            {
                if (car.Year >= 2017 &&
                    car.Engine.HorsePower > 330 &&
                    car.Tires.Select(tire => tire.Pressure).Sum() >= 9 &&
                    car.Tires.Select(tire => tire.Pressure).Sum() <= 10)
                { 
                   car.Drive(20);

                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }

            }
        }
    }
}
