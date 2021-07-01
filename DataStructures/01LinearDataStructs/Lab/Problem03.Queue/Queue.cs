namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            this._head = null;
            this.Count = 0;
        }

        public Queue(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> curNode = this._head;

            while (curNode != null)
            {
                if (curNode.Value.Equals(item))
                {
                    return true;
                }

                curNode = curNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.CheckIfEmpty();

            Node<T> toReturn = this._head;

            this._head = this._head.Next;

            this.Count--;

            return toReturn.Value;
        }



        public void Enqueue(T item)
        {
            Node<T> current = this._head;

            Node<T> toInsert = new Node<T>(item);

            if (current == null)
            {
                this._head = toInsert;

            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toInsert;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.CheckIfEmpty();

            return this._head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;

            while (current!=null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();


        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The Queue is Empty!");
            }
        }
    }
}