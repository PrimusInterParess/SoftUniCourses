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
                this._head = this._tail = null;
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
            throw new NotImplementedException();
        }

        public T GetFirst()
        {
            throw new NotImplementedException();
        }

        public T GetLast()
        {
            throw new NotImplementedException();
        }

        public T RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public T RemoveLast()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}