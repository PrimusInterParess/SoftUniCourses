using System;
using System.Linq;

namespace EnumeratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split().ToArray();

            StringEnumerator enumerator = new StringEnumerator(arr);

            while (enumerator.MoveNext())
            {
                  Console.WriteLine(enumerator.Current);
            }
        }
    }
}
