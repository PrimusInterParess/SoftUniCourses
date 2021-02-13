using System;
using System.Collections.Generic;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inpt = Console.ReadLine().Split();

            Stack<string> expressions = new Stack<string>();

            while (expressions.Count > 1)
            {
                int leftOperand = int.Parse(expressions.Pop());
                string sign = expressions.Pop();
                int rightOperand = int.Parse(expressions.Pop());

                if (sign == "+")
                {
                    expressions.Push((leftOperand + rightOperand).ToString());
                }
                else if (sign == "-")
                {
                    expressions.Push((leftOperand - rightOperand).ToString());

                }
            }

            Console.WriteLine(expressions.Pop());
        }
    }
}
