using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> ParsStringToInt = int.Parse;

            var numbers = Console.ReadLine().Split(", ").Select(ParsStringToInt).Where(n => n % 2 == 0).OrderBy(n=>n).ToArray();

            Console.WriteLine(string.Join(", ",numbers));

        }
    }
}
