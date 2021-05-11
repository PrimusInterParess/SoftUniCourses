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
            if (capacity < 0)
            {
                throw new IndexOutOfRangeException($"{capacity} is not a valid capacity ");
            }

            this._items = new T[capacity];
        }


        public int Count { get; private set; }

        public T this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Add(T item)
        {
            this.EnsureNotEmpty();
            this._items[this.Count++] = item;
            
        }



        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            throw new NotImplementedException();
        }



        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }



        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private void ValidateIndex(int index)
        {
            throw new NotImplementedException();
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == this._items.Length)
            {
                Resize();
            }

        }

        private void Resize()
        {
            var newArr = new T[this._items.Length*2];

            for (int i = 0; i < this._items.Length; i++)
            {
                newArr[i] = this._items[i];
            }

            this._items = newArr;
        }
    }
}
