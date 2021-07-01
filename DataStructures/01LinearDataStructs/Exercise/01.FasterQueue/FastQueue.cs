namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public FastQueue()
        {
            this._head = null;
            this._tail = null;
            this.Count = 0;
        }

        public FastQueue(Node<T> head)
        {
            this._head = _tail = head;
           
            this.Count++;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T item)
        {
            Node<T> toInsert = new Node<T>
            {
                Item = item
            };

            if (this.Count == 0)
            {
                this._head = this._tail = toInsert;
            }
            else
            {
                this._tail.Next = toInsert;
                this._tail = toInsert;

            }
        }

        

        public T Peek()
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