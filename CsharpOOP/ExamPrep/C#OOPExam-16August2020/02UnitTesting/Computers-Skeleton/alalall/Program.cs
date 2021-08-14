using System;
using System.Threading.Channels;

namespace alalall
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = a++;
            int c = ++a;
            Console.WriteLine(c);

        }
    }
}
