using System;
using System.Collections;
using System.Collections.Generic;

namespace ListPractice
{
    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;

        private T[] _items;

        public List(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity <= 0)
            {
                throw new AggregateException(nameof(capacity));
            }

            this._items = new T[capacity];
        }


        public int Count { get; private set; }

        public void Add(T item)
        {
            this.CheckForResize();
            this._items[Count++] = item;
        }

        public void Insert(int index, T item)
        {
            this.IndexValidation(index);
            this.CheckForResize();

            for (int i = Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.Count++;
        }

        public T this[int index]
        {
            get
            {
                this.IndexValidation(index);
                return this._items[index];
            }
            set
            {
                this.IndexValidation(index);
                this._items[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            this.IndexValidation(index);

            for (int i = index; i < Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[Count - 1] = default;
            this.Count--;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);

            return true;
        }

        private T[] Resize()
        {
            T[] newArr = new T[this.Count * 2];

            for (int i = 0; i < Count; i++)
            {
                newArr[i] = this._items[i];
            }

            return newArr;

        }

        private void IndexValidation(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void CheckForResize()
        {

            if (this._items.Length == Count)
            {
                this._items = Resize();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
