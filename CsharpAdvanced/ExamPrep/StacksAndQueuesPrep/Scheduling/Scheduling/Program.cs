using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intValues = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] threadsValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int taskValue = int.Parse(Console.ReadLine());

            Stack<int> task = GetStack(intValues);
            Queue<int> threads = GetQueue(threadsValues);

            bool treadsIsEmpty = false;
            bool shooted = false;

            Queue<int> shootedOnes = new Queue<int>();

            while (true)
            {



                if (task.Peek() == taskValue)
                {

                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskValue}");

                    Console.WriteLine(string.Join(" ", threads));
                    break;

                }
                else if (task.Peek() <= threads.Peek())
                {
                    threads.Dequeue();
                    task.Pop();
                }

                else if (threads.Peek() < task.Peek())
                {

                    threads.Dequeue();

                }
            }


        }

        private static bool CheckIfThreadIsEmpty(Queue<int> threads)
        {
            if (threads.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static Queue<int> GetQueue(int[] threadsValues)
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < threadsValues.Length; i++)
            {
                queue.Enqueue(threadsValues[i]);
            }

            return queue;
        }

        private static Stack<int> GetStack(int[] intValues)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < intValues.Length; i++)
            {
                stack.Push(intValues[i]);
            }

            return stack;
        }
    }
}
