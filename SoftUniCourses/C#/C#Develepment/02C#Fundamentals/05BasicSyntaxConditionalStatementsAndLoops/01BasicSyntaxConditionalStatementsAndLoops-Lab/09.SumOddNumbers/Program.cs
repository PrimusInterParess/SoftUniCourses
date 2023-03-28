using System;

namespace _09.SumOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                int result = 2 * i - 1;
                Console.WriteLine(result);
                sum += 2 * i - 1;

            }
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
