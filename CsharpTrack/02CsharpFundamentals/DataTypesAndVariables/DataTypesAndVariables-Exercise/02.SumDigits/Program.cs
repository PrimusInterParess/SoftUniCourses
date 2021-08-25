using System;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int digitSum = 0;

            while (number > 0)
            {
                int currentNumber = number % 10;
                number /= 10;

                digitSum += currentNumber;
            }

            Console.WriteLine(digitSum);
        }
    }
    }
}
