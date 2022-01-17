using System;
using System.Collections.Generic;

namespace _03SubSetSum_WithRepetition_
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 5, 2 };

            var target = 17;

            var boolArray = new bool[target + 1];

            boolArray[0] = true;

            for (int sum = 0; sum < boolArray.Length; sum++)
            {
                if (!boolArray[sum])
                {
                    continue;
                }

                foreach (var numb in numbers)
                {
                    var current = sum + numb;

                    if (current > target)
                    {
                        continue;
                    }


                    boolArray[current] = true;

                }
            }

            var subset = new List<int>();

            while (target > 0)
            {
                foreach (var number in numbers)
                {
                    var prepSum = target - number;

                    if (prepSum >= 0 && boolArray[prepSum])
                    {
                        subset.Add(number);
                        target = prepSum;

                    }
                }
            }

            Console.WriteLine(string.Join(' ',subset));
        }
    }
}
