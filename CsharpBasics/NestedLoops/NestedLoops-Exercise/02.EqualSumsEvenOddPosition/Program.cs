using System;

namespace _02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            for (int i = startNumber; i <= endNumber; i++)
            {
                int number = i;
                int evenSum = 0;
                int oddSum = 0;
                bool isEvenPosition = true;

                while (number > 0)
                {
                    int lastDigit = number % 10;

                    if (isEvenPosition)
                    {
                        evenSum += lastDigit;
                        isEvenPosition = false;
                    }
                    else
                    {
                        oddSum += lastDigit;
                        isEvenPosition = true;
                    }
                    number /= 10;

                }
                if (evenSum == oddSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
