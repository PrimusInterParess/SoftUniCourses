using System;
using System.Collections.Generic;

namespace Problem04.SinglyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();


            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);
            Node<int> node5 = new Node<int>(5);
            Node<int> node6 = new Node<int>(6);


            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);
            linkedList.AddFirst(5);
            linkedList.AddFirst(6);

            int last = linkedList.RemoveLast();


        }
    }
}