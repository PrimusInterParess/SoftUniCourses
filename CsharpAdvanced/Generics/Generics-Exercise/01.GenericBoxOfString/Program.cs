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

            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

               list.Add(input);

            }

            Box<double> newBox = new Box<double>(list);

            double indx = double.Parse(Console.ReadLine());

           

            Console.WriteLine(newBox.Count(indx));

        }
    }
}
