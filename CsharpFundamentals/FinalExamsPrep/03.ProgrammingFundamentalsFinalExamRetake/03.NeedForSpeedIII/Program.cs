using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Car
    {
        public string Name { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            AddCarsToList(cars);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] command = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "Drive":
                        Drive(cars, command[1], int.Parse(command[2]), int.Parse(command[3]));
                        break;
                    case "Refuel":
                        RefuelTank(cars, command[1], int.Parse(command[2]));
                        break;
                    case "Revert":
                        RevertingMileage(cars, command[1], int.Parse(command[2]));
                        break;
                }
            }

            foreach (Car car in cars.OrderByDescending(c => c.Mileage).ThenBy(c => c.Name))
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }

        }

        private static void RevertingMileage(List<Car> cars, string carName, int mileageToReverse)
        {
            foreach (Car car in cars)
            {
                if (car.Name == carName)
                {
                    car.Mileage -= mileageToReverse;

                    if (car.Mileage < 10000)
                    {
                        car.Mileage = 10000;
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"{car.Name} mileage decreased by {mileageToReverse} kilometers");
                    }
                }
            }
        }

        private static void RefuelTank(List<Car> cars, string carName, int tankToRefuel)
        {
            foreach (Car car in cars)
            {
                if (car.Name == carName)
                {
                    int fuelToAdd = 75 - car.Fuel;

                    if (tankToRefuel <= fuelToAdd)
                    {
                        car.Fuel += tankToRefuel;

                        Console.WriteLine($"{car.Name} refueled with {tankToRefuel} liters");
                    }
                    else if (tankToRefuel > fuelToAdd)
                    {
                        car.Fuel += fuelToAdd;
                        Console.WriteLine($"{car.Name} refueled with {fuelToAdd} liters");
                    }
                }
            }
        }

        private static void Drive(List<Car> cars, string carName, int distance, int requiredFuel)
        {
            foreach (Car car in cars)
            {
                bool getOut = false;
                if (car.Name == carName)
                {
                    getOut = true;
                    if (car.Fuel >= requiredFuel)
                    {
                        car.Mileage += distance;
                        car.Fuel -= requiredFuel;

                        Console.WriteLine($"{car.Name} driven for {distance} kilometers. {requiredFuel} liters of fuel consumed.");

                        if (car.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car.Name}!");
                            cars.Remove(car);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }

                if (getOut)
                {
                    return;
                }
            }
        }

        private static void AddCarsToList(List<Car> cars)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] carsData = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                cars.Add(new Car(carsData[0], int.Parse(carsData[1]), int.Parse(carsData[2])));
            }
        }
    }
}
