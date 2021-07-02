using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                arr.Add(i + 1);
            }

            int count = arr.Count;

            Console.WriteLine(arr.Count);

            int indexOfFive = arr.IndexOf(3);

            arr.RemoveAt(2);

            arr.Remove(3);

            bool contains = arr.Contains(4);

            arr.Insert(1,111);


        }
    }
}
