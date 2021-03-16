using System;

namespace TaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniLinkedList linkedList = new SoftUniLinkedList();

            for (int i = 0; i <=10; i++)
            {
                linkedList.AddHead(new Node(i));
            }
            
            var curNode = linkedList.Tail;


            for (int i = 0; i <=10; i++)
            {
                linkedList.AddLast(new Node(i));
            }

            Console.WriteLine("Foreach from Head: ");

            linkedList.ForeachHead(node =>
            {
                Console.WriteLine(node.Value);
            });

            linkedList.ForeachTail(node =>
            {
                Console.WriteLine(node.Value);
            });



        }
    }
}
