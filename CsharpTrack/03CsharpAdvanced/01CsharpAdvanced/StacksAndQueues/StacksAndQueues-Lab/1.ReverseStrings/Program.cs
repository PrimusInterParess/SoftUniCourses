using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> charStack = new Stack<char>();

            for (int a = 0; a < input.Length; a++)
            {
                charStack.Push(input[a]);
            }

            while (charStack.Count>0)
            {
                Console.Write(charStack.Pop());
            }

            Console.WriteLine();
        }
    }
}
