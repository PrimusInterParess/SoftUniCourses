using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BoxOfT<int> box = new BoxOfT<int>();

            box.Add(3);
            box.Add(5);
            box.Add(1);
            box.Add(2);

            Console.WriteLine(box.Count);
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Count);



        }
    }
}
