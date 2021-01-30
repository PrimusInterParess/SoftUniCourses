using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.MinValue;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    Console.WriteLine(maxNumber);
                    break;
                }

                int number = int.Parse(input);

                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }
        }
    }
}
