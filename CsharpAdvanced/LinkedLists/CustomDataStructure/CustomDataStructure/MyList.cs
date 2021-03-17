using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructure
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] data;

        private int capacity;

        public MyList()
        : this(4)
        {
        }

        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
        }

        public int Count { get; private set; }


        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.data[index];
            }
            set
            {

                this.ValidateIndex(index);

                this.data[index] = value;

            }
        }

        public void Insert(int index, T element)
        {
            this.ValidateIndex(index);

            this.CheckIfResizeIsNeeded();

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.data[i + 1] = this.data[i];
            }

            this.data[index] = element;

            this.Count++;
        }

        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);

            var result = this.data[index];

            for (int i = index + 1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }

            this.Count--;

            return result;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            T firstValue = this.data[firstIndex];
            data[firstIndex] = this.data[secondIndex];
            data[secondIndex] = firstValue;


        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(T number)
        {
            this.CheckIfResizeIsNeeded();

            this.data[this.Count] = number;

            this.Count++;
        }
        public void Clear()
        {
            this.Count = 0;
            this.data = new T[this.capacity];
        }

        private void Resize()
        {
            var newCapacity = this.data.Length * 2;

            var newData = new T[newCapacity];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                var massage = this.Count == 0
                    ? "The list is empty" :
                    $"The list has {this.Count} elements and it is zero-based";

                throw new Exception($"Index out of range .{massage}");
            }
        }

        private void CheckIfResizeIsNeeded()

        {
            if (Count == this.data.Length)
            {
                this.Resize();
            }
        }


        public IEnumerator<T> GetEnumerator()
            => (IEnumerator<T>)this.data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
