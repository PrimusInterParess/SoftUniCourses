using System;

namespace _03.Generating01Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStr = Console.ReadLine();

            Stack<char> charArr = new Stack<char>(inputStr);

            Console.WriteLine(string.Join("",charArr.ToArray()));
        }
    }
}
