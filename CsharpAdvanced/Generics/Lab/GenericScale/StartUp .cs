using System;

namespace GenericScale
{
    class Program
    {
        static void Main(string[] args)
        {
            var equals = new EQUALITYSCALE<int>(5,6);

            Console.WriteLine(equals.AreEqual());
        }
    }
}
