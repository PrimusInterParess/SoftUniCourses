using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            

            HashSet<string> carPlateSet = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
               
                var data = Regex.Split(input,", ");

                if (data[0] == "IN")
                {
                    carPlateSet.Add(data[1]);

                }
                else
                {
                    carPlateSet.Remove(data[1]);


                }


            }

            if (carPlateSet.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var p in carPlateSet)
                {
                    Console.WriteLine(p);
                }
            }


        }
    }
}
