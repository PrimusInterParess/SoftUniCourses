using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Dictionary<char, char> pairsParentheses = new Dictionary<char, char>()
            {
                { '(',')'},{'{','}'},{'[',']'}
            };

            if (expression.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> parenthesesChars = new Stack<char>();


            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                if (ch == '(' || ch == '{' || ch == '[')
                {
                    parenthesesChars.Push(ch);

                }
                else if (parenthesesChars.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                   

                    char expected = pairsParentheses[parenthesesChars.Pop()];

                    if (ch != expected)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                }
            }

            Console.WriteLine(parenthesesChars.Count == 0 ? "YES" : "NO");
        }
    }
}
