using System;

namespace DemoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {

            MyList<int> list = new MyList<int>();

            list.Add(1);
            list.Add(3);
            list.Add(2);

        }

        static void PrintElement<T>(T element)
        {
            Console.WriteLine($"Generics are cuul! Element:  {element}");
        }
    }


}
