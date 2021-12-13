using System;
using System.Linq;

namespace _01BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int searchingElement = int.Parse(Console.ReadLine());

            var result = BinarySearch(inputData, searchingElement);

            Console.WriteLine(result);
        }

        private static int BinarySearch(int[] inputData, int searchingElement)
        {
            int start = 0;

            var end = inputData.Length - 1;


            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (inputData[middle] == searchingElement)
                {
                    return middle;
                }

                if (inputData[middle] < searchingElement)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }

            }



            return -1;



        }

    }
}
