using System;

namespace _08.NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int MaxNum = int.MinValue;
            int MinNum = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (currNum > MaxNum)
                {
                    MaxNum = currNum;
                }
                if (currNum < MinNum)
                {
                    MinNum = currNum;
                }

            }
            Console.WriteLine($"Max number: {MaxNum}");
            Console.WriteLine($"Min number: {MinNum}");

        }
    }
}
