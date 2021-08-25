using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsToPark = int.Parse(Console.ReadLine());

            Dictionary<string, string> parkingRegister = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCarsToPark; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();

                switch (data[0])
                {
                    case"register":CarRegister(parkingRegister, data[1],data[2]);
                        break;
                    case "unregister":UnregisterUser(parkingRegister, data[1]);
                        break;
                }

               
            }
            foreach (var item in parkingRegister)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }

        static void UnregisterUser(Dictionary<string, string> parkingRegister, string userName)
        {
            if (!parkingRegister.ContainsKey(userName))
            {
                Console.WriteLine($"ERROR: user {userName} not found");
            }
            else
            {
                parkingRegister.Remove(userName);
                Console.WriteLine($"{userName} unregistered successfully");
            }
            
            
        }

        static void CarRegister(Dictionary<string,string> parkingRegister, string userName,string licencePlate)
        {
            if (parkingRegister.ContainsKey(userName))
            {
                Console.WriteLine($"ERROR: already registered with plate number {licencePlate}");
            }
            else
            {
                parkingRegister.Add(userName, licencePlate);
                Console.WriteLine($"{userName} registered {licencePlate} successfully");
            }
        }
    }
}
