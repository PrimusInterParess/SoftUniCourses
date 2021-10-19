using System;

using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] queueArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] stackArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = StackCreator(stackArray);

            Queue<int> queue = QueueCreator(queueArray);

            int points = 0;

            while (stack.Count != 0 && queue.Count != 0)
            {
                int stackInt = stack.Peek();

                int queueInt = queue.Peek();

                int sum = stackInt + queueInt;

                if (sum % 2 == 0)
                {
                    points += sum;
                    stack.Pop();
                    queue.Dequeue();

                }
                else
                {
                    queue.Enqueue(stackInt);
                    stack.Pop();

                }


            }



            Func<Queue<int>, Stack<int>, string>
                funkTonw = ((queue, stack) =>
                {
                    if (queue.Count == 0)
                    {
                        return $"First lootbox is empty";

                    }
                    else
                    {
                        return $"Second lootbox is empty";
                    }
                });

            Func<int, string> funcTonwFunc = numb =>
            {
                if (numb < 100)
                {
                    return $"Your loot was poor... Value: {numb}";
                }
                else
                {
                    return $"Your loot was epic! Value: {numb}";
                }
            };

            Console.WriteLine(funkTonw(queue,stack));

            Console.WriteLine(funcTonwFunc(points));



        }


        private static Stack<int> StackCreator(int[] numb)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numb.Length; i++)
            {
                stack.Push(numb[i]);

            }

            return stack;
        }

        private static Queue<int> QueueCreator(int[] numb)
        {
            Queue<int> queueArray = new Queue<int>();

            for (int i = 0; i < numb.Length; i++)
            {
                queueArray.Enqueue(numb[i]);
            }

            return queueArray;
        }
    }
}
