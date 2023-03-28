using System;

namespace CustomDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();

            for (int i = 0; i < 4; i++)
            {
                myList.Add(i);
            }

          
            Console.WriteLine();

            myList.Add(4);

            myList.RemoveAt(0);

            myList.Contains(5);

            myList.Contains(2);

            myList.Swap(2,3);

            Console.WriteLine(string.Join(" ",myList));

            


        }
    }
}
