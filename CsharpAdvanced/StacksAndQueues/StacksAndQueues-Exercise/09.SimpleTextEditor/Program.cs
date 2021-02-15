using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {


            int n = int.Parse(Console.ReadLine());

            StringBuilder manipulative = new StringBuilder();

            Stack<string> stack = new Stack<string>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "1":
                        manipulative.Append(input[1]);

                        stack.Push(manipulative.ToString());
                        break;
                    case "2":
                        int count = int.Parse(input[1]);

                        manipulative = manipulative.Remove(manipulative.Length - count, count);
                        stack.Push(manipulative.ToString());

                        break;
                    case "3":
                        Console.WriteLine(manipulative[int.Parse(input[1]) - 1]);
                        break;
                    case "4":
                        stack.Pop();

                        manipulative = new StringBuilder();

                        manipulative.Append(stack.Count > 0 ? stack.Peek() : "");

                        break;

                }
            }


        }
    }
}