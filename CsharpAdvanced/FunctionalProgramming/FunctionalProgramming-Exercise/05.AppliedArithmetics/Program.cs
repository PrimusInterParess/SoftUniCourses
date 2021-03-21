using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = arr => { Console.WriteLine(string.Join(" ",arr)); };

            int[] numbersInts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;


            while ((input = Console.ReadLine()) != "end")
            {
                if (input=="print")
                {
                    print(numbersInts);
                }
                else
                {
                    Func<int[], int[]> procecssor = getProcessorFunc(input);

                    numbersInts = procecssor(numbersInts);
                }

            }
        }

        static Func<int[], int[]> getProcessorFunc(string input)
        {
            Func<int[], int[]> processor = null;

            if (input == "add")
            {
                processor = new Func<int[], int[]>(arr =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]++;
                    }

                    return arr;
                });
            }
            else if (input == "multiply")
            {
                processor = new Func<int[], int[]>(arr =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] *= 2;
                    }

                    return arr;
                });
            }
            else if (input=="subtract")
            {
                processor = new Func<int[], int[]>(arr =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]--;
                    }

                    return arr;
                });
            }

            return processor;
        }
    }
}
