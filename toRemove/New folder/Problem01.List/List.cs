namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity <= 0)
            {
                throw new InvalidOperationException(nameof(capacity));
            }

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                ValidateIndex(index);
                this._items[index] = value;
            }
        }



        public int Count { get; private set; }

        public void Add(T item)
        {
            CheckCapacity();

            this._items[Count++] = item;
        }



        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            CheckCapacity();

            for (int i = Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int indexOf = this.IndexOf(item);

            if (indexOf == -1)
            {
                return false;
            }

            this.RemoveAt(indexOf);

            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[Count - 1] = default;

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();


        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void CheckCapacity()
        {
            if (this.Count == this._items.Length)
            {
                this._items = Grow();
            }
        }

        private T[] Grow()
        {
            T[] newArr = new T[this._items.Length * 2];

            Array.Copy(this._items, newArr, this._items.Length);

            return newArr;
        }
    }
}