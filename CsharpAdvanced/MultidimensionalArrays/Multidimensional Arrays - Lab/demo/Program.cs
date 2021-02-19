using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                for (int k = 0; k < number; k++)
                {
                    for (int j = 0; j < number; j++)
                    {
                        char firstChar = (char)('a' + i);
                        char secondChar = (char)('a' + k);
                        char thirdChar = (char)('a' + j);

                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
