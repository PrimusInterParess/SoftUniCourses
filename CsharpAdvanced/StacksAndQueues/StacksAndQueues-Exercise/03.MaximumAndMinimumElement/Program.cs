using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 x – Push the element x into the stack.
            //2 – Delete the element present at the top of the stack.
            //3 – Print the maximum element in the stack.
            //4 – Print the minimum element in the stack.

            Stack<int> numbStack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] actions = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (actions[0])
                {

                    case 1:
                        numbStack.Push(actions[1]);
                        break;
                    case 2:
                        numbStack.Pop();
                        break;
                    case 3:
                        if (numbStack.Count != 0)
                        {
                            Console.WriteLine(numbStack.Max());

                        }
                        break;
                    case 4:
                        if (numbStack.Count != 0)
                        {
                            Console.WriteLine(numbStack.Min());
                        }
                        break;
                }

            }

            Console.WriteLine(string.Join(", ", numbStack));
        }
    }
}
