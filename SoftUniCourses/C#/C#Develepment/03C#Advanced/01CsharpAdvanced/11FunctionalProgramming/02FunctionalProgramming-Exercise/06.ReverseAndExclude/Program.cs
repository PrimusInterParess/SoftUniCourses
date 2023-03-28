using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int devisibleNumber = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseFunc = arr => arr.Reverse().ToArray();


            Func<int, bool> funkTonw = first => first % devisibleNumber != 0;
            
            numbers = reverseFunc(numbers).Where(funkTonw).ToArray();

            Console.WriteLine(string.Join(" ",numbers));

        }


    }


}
