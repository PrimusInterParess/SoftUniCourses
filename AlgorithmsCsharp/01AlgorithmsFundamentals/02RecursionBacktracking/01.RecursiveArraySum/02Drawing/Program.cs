using System;

namespace _02Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            RecursiveDrawing(n, '\0');
        }

        private static void RecursiveDrawing(int n, char c)
        {
            if (n <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));
            RecursiveDrawing(n - 1, '*');
            Console.WriteLine(new string('#', n));
            
        }
    }
}
