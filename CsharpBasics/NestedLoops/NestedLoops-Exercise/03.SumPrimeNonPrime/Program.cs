using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeNumbersSum = 0;
            int nonPrimeNumbers = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    bool isPrime = true;
                    int numberSqrt = (int)Math.Sqrt(number);

                    for (int i = 2; i <= numberSqrt; i++)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }

                    }
                    if (isPrime)
                    {
                        primeNumbersSum += number;
                    }
                    else
                    {
                        nonPrimeNumbers += number;
                    }
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeNumbersSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumbers}");
        }
    }
}
