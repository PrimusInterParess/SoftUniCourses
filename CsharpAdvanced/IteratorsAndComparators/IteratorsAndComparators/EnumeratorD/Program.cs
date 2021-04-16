using System;

namespace EnumeratorD
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();

            StringEnumerator enumerator = new StringEnumerator(array);

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
