using System;
using System.Runtime.ExceptionServices;

namespace ConstraintsG
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectComparor<int, int> objComp = new ObjectComparor<int, int>();

            bool result =  objComp.IsFirstBigger(5, 4);

            Console.WriteLine(result);

        }
    }
}
 