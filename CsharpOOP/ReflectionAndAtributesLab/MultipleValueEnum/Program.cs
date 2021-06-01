using System;

namespace MultipleValueEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    [Flags]
    enum Days
    {
        Monday,
        Tuesday,
        Wednesday
    }
}
