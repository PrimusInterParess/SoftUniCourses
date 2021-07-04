using System.Reflection.Metadata.Ecma335;

namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;


        public DoublyLinkedList()
        {
            this._head = this._tail = null;
        }
        public DoublyLinkedList(Node<T> head)
        {
            this._head = this._tail = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> toInsert = new Node<T>
            {
                Item = item,

            };

            if (this.Count == 0)
            {
                this._head = this._tail = toInsert;
            }
            else
            {

                this._head.Previous = toInsert;
                toInsert.Next = this._head;
                this._head = toInsert;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> toInsert = new Node<T>()
            {
                Item = item
            };

            if (this.Count == 0)
            {
                this._head = this._tail = toInsert;
            }
            else
            {
                toInsert.Previous = this._tail;
                this._tail.Next = toInsert;
                this._tail = toInsert;
            }

            this.Count++;

        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return this._head.Item;
        }

        public T GetLast()
        {

            EnsureNotEmpty();

            return this._tail.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            Node<T> toReturn = this._head;
            Node<T> newHead = null;

            if (this.Count == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                newHead = this._head.Next;
                newHead.Previous = null;
                this._head = newHead;
            }

            this.Count--;
            return toReturn.Item;

        }

        public T RemoveLast()
        {

            EnsureNotEmpty();

            Node<T> toReturn = this._tail;
            Node<T> newTail = null;

            if (this.Count == 1)
            {
                this._head = this._tail = null;
            }
            else
            {
                newTail = this._tail.Previous;
                newTail.Next = null;
                this._tail = newTail;
            }

            this.Count--;
            return toReturn.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("not cool at all");
            }
        }
    }
}