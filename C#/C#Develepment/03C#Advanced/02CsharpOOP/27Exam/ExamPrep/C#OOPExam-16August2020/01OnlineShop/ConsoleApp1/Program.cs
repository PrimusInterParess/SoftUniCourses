using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            word = word.Reverse().ToString();

           Console.WriteLine(word);
        }
    }
}
