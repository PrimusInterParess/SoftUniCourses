using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfengines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfengines; i++)
            {
                string[] engineData = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                engines.Add(FormingNewEngine(engineData));

            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string engineModel = carData[1];

                Engine engineToAdd = engines.First(e => e.Model == engineModel);

                cars.Add(FormingCar(carData, engineToAdd));

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }


        }

        private static Car FormingCar(string[] carData, Engine engine)
        {
            string carModel = carData[0];

            

            int carWeight = 0;

            Car car = null;

            if (carData.Length == 2)
            {
                return car = new Car(carModel, engine);
            }
            else if (carData.Length == 3)
            {
                int toDefine;

                bool isWeight = int.TryParse(carData[2], out toDefine);

                if (isWeight)
                {
                    return car = new Car(carModel, engine, toDefine);
                }
                else
                {
                    return car = new Car(carModel, engine, carData[2]);
                }

            }

            return car = new Car(carModel, engine, int.Parse(carData[2]), carData[3]);

        }

        private static Engine FormingNewEngine(string[] engineData)
        {


            Engine engine = null;

            string engineModel = engineData[0];

            int enginePower = int.Parse(engineData[1]);

            int displacment = 0;



            if (engineData.Length == 2)
            {
                return engine = new Engine(engineModel, enginePower);
            }
            else if (engineData.Length == 3)
            {
                int toDifine;

                bool isDisplacment = int.TryParse(engineData[2], out toDifine);

                if (isDisplacment)
                {
                    return engine = new Engine(engineModel, enginePower, toDifine);
                }
                else
                {
                    return engine = new Engine(engineModel, enginePower, engineData[2]);
                }

            }

            return engine = new Engine(engineModel, enginePower, int.Parse(engineData[2]), engineData[3]);




        }
    }
}
