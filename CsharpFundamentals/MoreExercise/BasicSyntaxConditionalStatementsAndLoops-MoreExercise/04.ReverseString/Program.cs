using System;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string drow = string.Empty;

            for (int i = word.Length - 1; i >= 0; i--)
            {
                drow += word[i];
            }

            Console.WriteLine(drow);
        }
    }
}
