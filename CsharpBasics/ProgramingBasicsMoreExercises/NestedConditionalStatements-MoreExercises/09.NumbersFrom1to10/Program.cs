using System;

namespace _09.NumbersFrom1to10
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1;

            while (true)
            {
                Console.WriteLine(number);
                if (number == 10)
                {
                    break;
                }
                number++;
            }
        }
    }
}
