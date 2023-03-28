using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());
            int sumOfChars = 0;

            for (int i = 0; i < numberOfChars; i++)
            {
                char input = char.Parse(Console.ReadLine());

                sumOfChars += (int)(input);

            }
            Console.WriteLine($"The sum equals: {sumOfChars}");
        }
    }
}
