using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection.Metadata;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class SoftUniLinkedList<T>
    {
        private int count = 0;

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public void AddHead(Node<T> node)
        {
            count++;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;

            Head.Previous = node;

            Head = node;
        }

        public void AddLast(Node<T> node)
        {
            count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }


        public Node<T> RemoveHead()
        {
            count--;

            if (Head == null)
            {
                return null;
            }

            var nodeToReturn = Head;


            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;

            }
            else
            {
                Head = null;
                Tail = null;
            }


            return nodeToReturn;
        }

        public Node<T> RemoveTail()
        {
            count--;

            if (Tail == null)
            {
                return null;
            }

            var nodeToReturn = Tail;


            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;

            }
            else
            {
                Tail = null;
                Head = null;
            }


            return nodeToReturn;
        }

        public void Foreach(Action<Node<T>> action)
        {

            Node<T> currNode = Head;

            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Next;
            }
        }

        public void ForeachHead(Action<Node<T>> action)
        {

            Node<T> currNode = Head;

            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Next;
            }
        }

        public void ForeachTail(Action<Node<T>> action)
        {

            Node<T> currNode = Tail;

            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Previous;
            }
        }

        public T[] ToArray()
        {

            int index = 0;

            T[] array = new T[count];

            ForeachHead(node =>
            {
                array[index] = node.Value;
                index++;
            });

            return array;
        }


    }
}
