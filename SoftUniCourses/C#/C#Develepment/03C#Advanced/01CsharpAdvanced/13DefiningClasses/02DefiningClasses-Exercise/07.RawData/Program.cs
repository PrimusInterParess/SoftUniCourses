using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> carList = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carData[0];

                double engineSpeed = double.Parse(carData[1]);

                double engineHP = double.Parse(carData[2]);

                Engine engine = new Engine(engineSpeed, engineHP);

                double cargoWeight = double.Parse(carData[3]);

                string cargoType = carData[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                string[] tyreData = carData.Skip(5).ToArray();

                Tire[] tires = CollectsTires(tyreData);

                carList.Add(new Car(model, engine, tires, cargo));
            }

            string filterCargoType = Console.ReadLine();

            carList = carList.Where(c => FilterCargoArg(filterCargoType, c)).ToList();

            foreach (var car in carList)
            {
                Console.WriteLine(car.MODEL);
            }
        }

        static bool FilterCargoArg(string filter, Car car)
        {
            string currentCarCargoType = car.Cargo.CargoType;

            if (filter == "fragile")
            {
                if (filter == currentCarCargoType && ChecksIfTireIsOK(car.Tires))
                {
                    return true;

                }
                return false;

            }
            else
            {
                if (car.Engine.HorsePower > 250)
                {
                    return true;
                }

                return false;
            }


        }

        private static bool ChecksIfTireIsOK(Tire[] tires)
        {
            foreach (var tire in tires)
            {
                if (tire.Pressure < 1)
                {
                    return true;
                }
            }

            return false;
        }

        static Tire[] CollectsTires(string[] tyreData)
        {
            Tire[] tires = new Tire[4];

            for (int i = 0; i < 4; i++)
            {
                double pressure = double.Parse(tyreData[0]);

                int year = int.Parse(tyreData[1]);

                tires[i] = new Tire(pressure, year);
            }

            return tires;

        }
    }
}
