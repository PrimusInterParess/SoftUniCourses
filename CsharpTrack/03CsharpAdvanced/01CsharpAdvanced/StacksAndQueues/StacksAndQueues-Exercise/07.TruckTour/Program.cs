using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPetrolStation = int.Parse(Console.ReadLine());

            Queue<string> petrolStationStop = new Queue<string>();

            for (int i = 0; i < numberOfPetrolStation; i++)
            {
                string stationsData = Console.ReadLine();

                petrolStationStop.Enqueue(stationsData + $" {i}");

            }

            int totalPetrol = 0;


            for (int i = 0; i < numberOfPetrolStation; i++)
            {
                string info = petrolStationStop.Dequeue();

                int[] currentInfo = info.Split().Select(int.Parse).ToArray();

                int petrol = currentInfo[0];
                int distance = currentInfo[1];

                totalPetrol += petrol;

                if (totalPetrol >= distance)
                {
                    totalPetrol -= distance;
                }
                else
                {
                    totalPetrol = 0;
                    i = -1;
                }

                petrolStationStop.Enqueue(info);
            }

            string[] indexStrings = petrolStationStop.Dequeue().Split().ToArray();

            Console.WriteLine(indexStrings[2]);

        }


    }
}
