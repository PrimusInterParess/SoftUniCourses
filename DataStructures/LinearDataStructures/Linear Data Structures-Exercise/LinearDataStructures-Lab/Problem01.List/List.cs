using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem01.List
{
    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity <= 0)
            {
                throw new IndexOutOfRangeException($"{capacity} is not a valid capacity ");
            }

            this._items = new T[capacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[index];
<<<<<<< HEAD
=======


>>>>>>> 326967a2049ae78b33e0e381db9f7c78f206bba3
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public void Add(T item)
        {
            this.GrowIfNecessery();
            this._items[this.Count++] = item;
<<<<<<< HEAD
=======

        }

>>>>>>> 326967a2049ae78b33e0e381db9f7c78f206bba3

        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
<<<<<<< HEAD
            this.GrowIfNecessery();

            for (int i = Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.Count++;
=======

            this.EnsureNotEmpty();

            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;

            this.Count++;

        }
>>>>>>> 326967a2049ae78b33e0e381db9f7c78f206bba3



        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
<<<<<<< HEAD
        } 
=======
        }
>>>>>>> 326967a2049ae78b33e0e381db9f7c78f206bba3

        public int IndexOf(T item)
        {

            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }
<<<<<<< HEAD

=======
>>>>>>> 326967a2049ae78b33e0e381db9f7c78f206bba3
            return -1;
        }

        public bool Remove(T item)
        {
            int indexOfElement = this.IndexOf(item);

            if (indexOfElement == -1)
            {
                return false;
            }

            this.RemoveAt(indexOfElement);

            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

<<<<<<< HEAD
            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.Count - 1] = default;

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
=======
            for (int i = index; i < Count - 1; i++)
            {
                this._items[i] = this._items[index + 1];
            }

            this._items[this.Count - 1] = default;

            this.Count--;

        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
>>>>>>> 326967a2049ae78b33e0e381db9f7c78f206bba3
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
<<<<<<< HEAD

        private void GrowIfNecessery()
=======


        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"The given index {index} is invalid!");
            }
        }

        private void EnsureNotEmpty()
>>>>>>> 326967a2049ae78b33e0e381db9f7c78f206bba3
        {
            if (this.Count == this._items.Length)
            {
                Resize();
            }

        }

        private void Resize()
        {
            var newArr = new T[this._items.Length * 2];

            for (int i = 0; i < this._items.Length; i++)
            {
                newArr[i] = this._items[i];
            }

            this._items = newArr;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"The given index {index} is invalid");
            }
        }
    }
}
