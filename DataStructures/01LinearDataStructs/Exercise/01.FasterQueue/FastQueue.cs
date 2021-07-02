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
            var current = this._head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();
            Node<T> toReturn = this._head;

            if (this.Count == 1)
            {
                this._head = _tail = null;
            }
            else
            {
                this._head = this._head.Next;
            }

            this.Count--;
            return toReturn.Item;
        }

        public void Enqueue(T item)
        {
            Node<T> toInsert = new Node<T>(item);

            if (this.Count == 0)
            {
                this._head = this._tail = toInsert;
            }
            else
            {
                this._tail.Next = toInsert;
                this._tail = toInsert;
            }

            this.Count++;

        }



        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
            
        

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}