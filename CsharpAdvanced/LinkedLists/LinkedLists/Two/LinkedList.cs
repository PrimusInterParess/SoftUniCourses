using System;
using System.Collections.Generic;
using System.Text;

namespace Two
{
    public class LinkedList
    {
        private int count = 0;

        public Node Head { get; set; }

        public Node Tail { get; set; }


        public void AddHead(Node node)
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

        public void AddTail(Node node)
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

        public Node RemoveHead()
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

        public Node RemoveTail()
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

        public void ForeachHead(Action<Node> action)
        {
            Node currNode = Head;

            while (currNode != null)
            {
                action(currNode);

                currNode = currNode.Next;
            }
        }

        public void ForeachTail(Action<Node> action)
        {
            Node currNode = Tail;

            while (currNode != null)
            {
                action(currNode);

                currNode = currNode.Previous;
            }
        }

        public int[] LinkedListToArray()
        {
            int index = 0;

            int[] array = new int[count];

            ForeachHead(node =>
            {
                array[index] = node.Value;

                index++;
            });

            return array;
        }
    }
}
