using System;

namespace _01Task
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Dimitrichko e top");
            }

            Print(10);

        }

        private static void Print(int i)
        {
            if (i==0)
            {
                return;
            }
            Console.WriteLine("Dimitrichko e top");
            Print(i-1);
        }
    }
}
