using System;

namespace _05.PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startLoop = int.Parse(Console.ReadLine());
            int endLoop = int.Parse(Console.ReadLine());

            for (int i = startLoop; i <= endLoop; i++)
            {
                Console.Write((char)i + " ");
            }
            Console.WriteLine();
        }
    }
}
