using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            bool found = false;

            int count = 0;

            for (int s = startNumber; s <= endNumber; s++)
            {
                for (int e = startNumber; e <= endNumber; e++)
                {
                    int sum = s + e;
                    count++;

                    if (sum == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{count} ({s} + {e} = {magicNumber})");
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }

            }
            if (!found)
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNumber}");

            }

        }
    }
}
