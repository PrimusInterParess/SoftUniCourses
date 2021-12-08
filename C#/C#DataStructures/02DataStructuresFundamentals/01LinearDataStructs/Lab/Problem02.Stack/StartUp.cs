using System;

namespace Problem02.Stack
{
    public class StartUp
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();

            Stack<int> newStack = new Stack<int>();


           newStack.Push(1);
           newStack.Push(2);
           newStack.Push(3);
           newStack.Push(4);

           Console.WriteLine(newStack.Contains(1));

        }
    }
}