using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {

            string[] strArr = ArrayCreator.Create(5, "Pesho");


            foreach (var str  in strArr)
            {
                Console.Write(str + " ");
            }
        }
    }
}
