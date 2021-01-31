using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int copyNumber = number;

            int currentNumber = 0;
            int factorialNumbersSum = 0;

            while (copyNumber != 0)
            {
                currentNumber = copyNumber % 10;
                copyNumber /= 10;

                int factorialNumber = 1;

                for (int i = 1; i <= currentNumber; i++)
                {
                    factorialNumber *= i;
                }

                factorialNumbersSum += factorialNumber;
            }

            string result = string.Empty;

            if (factorialNumbersSum == number)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }

            Console.WriteLine(result);
        }
    }
}
