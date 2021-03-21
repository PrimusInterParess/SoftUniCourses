using System;

namespace GenericArrayCreator

{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] arrStrings = ArrayCreator.Create(5, "pesho");

            Console.WriteLine(string.Join(" ",arrStrings));

        }
    }
}
