namespace _01._BrowserHistory

{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IEnumerable
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {
            this._head = null;
            this.Count = 0;
        }

        public SinglyLinkedList(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void Clear()
        {
            this._head = null;
            this.Count = 0;
        }

        public void AddFirst(T item)
        {
            var toInsert = new Node<T>(item);

            if (this._head == null)
            {
                this._head = toInsert;
            }
            else
            {
                toInsert.Next = _head;
                this._head = toInsert;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var toInsert = new Node<T>(item);

            var current = this._head;

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

        public T GetFirst()
        {
            this.CheckIfNotEmpty();

            return this._head.Value;
        }





        public T GetLast()
        {
            this.CheckIfNotEmpty();

            var current = this._head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            this.CheckIfNotEmpty();

            var toReturn = this._head.Value;

            this._head = this._head.Next;

            this.Count--;

            return toReturn;
        }

        public bool Contains(T value)
        {
            var searched = new Node<T>(value);

            var current = this._head;

            while (current != null)
            {
                if (current.Value.Equals(searched.Value))
                {
                    return true;
                }

                current = current.Next;

            }

            return false;
        }

        public T RemoveLast()
        {
            this.CheckIfNotEmpty();

            Node<T> current = this._head;

            Node<T> last = null;

            if (current.Next == null)
            {
                last = this._head;
                this._head = null;
            }
            else
            {
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }

                last = current.Next;
                current.Next = null;
            }

            this.Count--;

            return last.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {

            Node<T> current = this._head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void CheckIfNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Seriously?");
            }
        }
    }
}