using System;

namespace _04Fibonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            int fib = int.Parse(Console.ReadLine());

            Console.ReadLine(Fibonacci(fib));

        }

        private static int Fibonacci(int fib)
        {

            if (fib == 0)
            {
                return 0;
            }
            if(fib==1|| fib==2)
            {
                return 1;
            }

            return Fibonacci(fib - 1) + Fibonacci(fib - 2);

        }
    }
}
