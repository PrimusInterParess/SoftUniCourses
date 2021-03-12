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

            for (int i = 0; i < numberOfengines; i++)
            {
                string[] engineData = Console.ReadLine()
                        .Split(new char []{' '})
                        .ToArray();

                string engineModel = engineData[0];

                int enginePower = int.Parse(engineData[1]);

                int displacement = int.Parse(engineData[2]);

                string efficiency = engineData[3];

                engines.Add(new Engine(engineModel, enginePower, displacement, efficiency));
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(new char[] {' ' })
                    .ToArray();



            }


        }
    }
}
