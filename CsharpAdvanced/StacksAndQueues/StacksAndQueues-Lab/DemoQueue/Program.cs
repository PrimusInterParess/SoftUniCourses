using System;
using System.Collections;
using System.Collections.Generic;

namespace DemoQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> books = new Queue<string>();

            books.Enqueue("Pinokio");
            books.Enqueue("War and peace");
            books.Enqueue("Alchemist");

            Console.WriteLine(books.Peek());
            Console.WriteLine(books.Dequeue());

            Console.WriteLine(books.Peek());
        }
    }
}
