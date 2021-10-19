using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> bracketIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracketIndexes.Push(i);
                }

                if (input[i] == ')')
                {
                    int startIndex = bracketIndexes.Pop();

                    Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                }
            }


        }
    }
}
