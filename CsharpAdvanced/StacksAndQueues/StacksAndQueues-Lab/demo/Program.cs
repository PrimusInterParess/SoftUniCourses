using System;
using System.Collections;
using System.Collections.Generic;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> books = new Stack<string>();

            books.Push("Pinokio");
            books.Push("War and peace");
            books.Push("Alchemist");

            Console.WriteLine(books.Pop());
            Console.WriteLine(books.Pop());

            Console.WriteLine(books.Peek());
            
        }
    }
}
