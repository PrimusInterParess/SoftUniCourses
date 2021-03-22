using System;
using System.Collections.Generic;
using System.Text;

namespace Two
{
    public class LinkedList<T>
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

            node.Previous = node;

            Head = node;
        }

        public void AddTail(Node<T> node)
        {
            count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Previous = Tail;

            node.Next = node;

            Tail = node;
        }

        public Node<T> RemoveHead()
        {
            count--;

            if (Head == null)
            {
                return null;
            }

            var toReturn = Head;

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


            return toReturn;
        }

        public Node<T> RemoveTail()
        {
            count--;

            if (Tail == null)
            {
                return null;
            }

            var toReturn = Tail;

            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }

            return toReturn;
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

        public T[] LinkedListToArray()
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
