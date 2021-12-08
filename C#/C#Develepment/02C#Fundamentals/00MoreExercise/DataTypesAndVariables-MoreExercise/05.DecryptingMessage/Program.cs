using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            int number = int.Parse(Console.ReadLine());

            string word = string.Empty;

            for (int i = 0; i < number; i++)
            {

                char letter = char.Parse(Console.ReadLine());

                int digits = (int)(letter) + key;

                word += (char)(digits);
            }

            Console.WriteLine(word);
        }
    }
}
