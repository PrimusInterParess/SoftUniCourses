using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, int> ParsFromStrToInt = int.Parse;

            var numbers = Console.ReadLine().Split(", ").Select(ParsFromStrToInt).ToArray();

            Func<int[], int> SumsArray = Sum;

            int sumOfNumbers = SumsArray(numbers);

            int counter = ArrayCounter(numbers);

            Console.WriteLine(counter);

            Console.WriteLine(sumOfNumbers);




        }

        static int ArrayCounter(int[] array)
        {
            int counter = 0;

            for (int ar = 0; ar < array.Length; ar++)
            {
                counter++;
            }

            return counter;

        }

        static int Sum(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

    }
}
