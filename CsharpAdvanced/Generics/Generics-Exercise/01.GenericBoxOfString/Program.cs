using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> strings = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                strings.Add(input);
            }

            double toCompare = double.Parse(Console.ReadLine());


            Box<double> strigBox = new Box<double>(strings);

            Console.WriteLine(strigBox.CountGreaterElements(toCompare));
          

           






        }
    }
}
