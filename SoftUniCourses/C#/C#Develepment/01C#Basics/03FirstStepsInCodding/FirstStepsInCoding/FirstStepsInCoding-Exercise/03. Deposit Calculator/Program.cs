using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());

            double depositLength = double.Parse(Console.ReadLine());

            double interestRate = double.Parse(Console.ReadLine());

            double anualInterestRate = interestRate / 100 * depositSum;

            double moutlyIntRate = anualInterestRate / 12;

            double sum = depositSum + (moutlyIntRate * depositLength);

            Console.WriteLine(sum);
        }
    }
}
