using System;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int maxNum = 0;
            int midNUm = 0;
            int minNum = 0;

            if (firstNumber > secondNumber && firstNumber > thirdNumber)
            {
                maxNum = firstNumber;
            }
            if (firstNumber > secondNumber && firstNumber < thirdNumber)
            {
                midNUm = firstNumber;
            }
            if (firstNumber < secondNumber && firstNumber > thirdNumber)
            {
                midNUm = firstNumber;
            }
            if (firstNumber < secondNumber && firstNumber < thirdNumber)
            {
                minNum = firstNumber;
            }
            if (secondNumber > firstNumber && secondNumber > thirdNumber)
            {
                maxNum = secondNumber;
            }
            if (secondNumber < firstNumber && secondNumber > thirdNumber)
            {
                midNUm = secondNumber;
            }
            if (secondNumber > firstNumber && secondNumber < thirdNumber)
            {
                midNUm = secondNumber;
            }
            if (secondNumber < firstNumber && secondNumber < thirdNumber)
            {
                minNum = secondNumber;
            }
            if (thirdNumber > firstNumber && thirdNumber > secondNumber)
            {
                maxNum = thirdNumber;
            }
            if (thirdNumber < firstNumber && thirdNumber > secondNumber)
            {
                midNUm = thirdNumber;
            }
            if (thirdNumber > firstNumber && thirdNumber < secondNumber)
            {
                midNUm = thirdNumber;
            }
            if (thirdNumber < firstNumber && thirdNumber < secondNumber)
            {
                minNum = thirdNumber;
            }

            Console.WriteLine(maxNum);
            Console.WriteLine(midNUm);
            Console.WriteLine(minNum);
        }
    }
}
