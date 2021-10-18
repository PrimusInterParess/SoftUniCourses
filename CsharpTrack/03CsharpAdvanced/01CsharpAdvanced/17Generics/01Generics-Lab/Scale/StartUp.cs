using System;

namespace GenericScale
{
    class StatUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equality = new EqualityScale<int>(5,6);

            Console.WriteLine(equality.AreEquals());
        }
    }
}
