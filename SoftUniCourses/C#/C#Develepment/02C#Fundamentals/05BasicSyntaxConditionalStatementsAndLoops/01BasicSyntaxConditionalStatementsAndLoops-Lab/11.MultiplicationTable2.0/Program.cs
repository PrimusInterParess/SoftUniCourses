using System;

namespace _11.MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            for (int i = times; i <= 10; i++)
            {
                int product = integer * i;
                Console.WriteLine($"{integer} X {i} = { product}");
            }
            if (times > 10)
            {
                int exeption = integer * times;
                Console.WriteLine($"{integer} X {times} = {exeption}");
            }
        }
    }
}
