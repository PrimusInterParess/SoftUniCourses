using System;

namespace GenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintKeyValuePair("Oli" , 10);
        }

        static void PrintKeyValuePair<TKey, TValue>(TKey tKey, TValue tValue)
        {

            Console.WriteLine($"Key{tKey} . Value{tValue}");
        }
    }
}
