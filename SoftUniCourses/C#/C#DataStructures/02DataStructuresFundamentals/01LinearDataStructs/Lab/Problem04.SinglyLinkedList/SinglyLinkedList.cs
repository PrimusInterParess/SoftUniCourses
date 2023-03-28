using System.Runtime.InteropServices;

namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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
            this.Count++;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> current = new Node<T>(item, this._head);
            this._head = current;
            this.Count++;
        }


        public void AddLast(T item)
        {
            Node<T> toInsert = new Node<T>(item);
            Node<T> current = this._head;

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
            this.CheckIfEmpty();

            return this._head.Value;
        }



        public T GetLast()
        {
            this.CheckIfEmpty();

            Node<T> current = _head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;

        }

        public T RemoveFirst()
        {
            CheckIfEmpty();

            Node<T> current = this._head;

            this._head = this._head.Next;

            this.Count--;

            return current.Value;

        }

        public T RemoveLast()
        {
            CheckIfEmpty();

            Node<T> current = this._head;
            Node<T> last = null;

            if (current.Next==null)
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

        private void CheckIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked listIs empty!");
            }
        }
    }
}