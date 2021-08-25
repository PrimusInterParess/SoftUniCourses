using System;

namespace N_
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(NFactorial(n));
        }

        private static int NFactorial(int i)
        {
            if (i== 1)
            {
                return 1;
            }

            return i * NFactorial(i - 1);
        }
    }
}
