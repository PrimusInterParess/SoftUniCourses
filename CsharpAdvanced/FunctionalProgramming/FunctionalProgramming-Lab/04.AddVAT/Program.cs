using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> strToDouble = double.Parse;

            double[] numbersBeforeVAT = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(strToDouble).ToArray();

            Func<double[], double[]> doubleFunc = DoubleFunc;

            var doubleWithVAT = doubleFunc(numbersBeforeVAT);

            foreach (var doubles in doubleWithVAT)
            {
                Console.WriteLine($"{doubles:f2}");
            }
        }

        private static double[] DoubleFunc(double[] doubles)
        {

            var doubleWithVAT = new List<double>();

            for (int i = 0; i < doubles.Length; i++)
            {
                doubleWithVAT.Add(doubles[i] * 1.2);
            }

            return doubleWithVAT.ToArray();
        }
    }
}
