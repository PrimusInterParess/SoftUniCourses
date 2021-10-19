using System;

namespace _07.ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string symbols = Console.ReadLine();

            Console.WriteLine($"{firstName}{symbols}{lastName}");
        }
    }
}
