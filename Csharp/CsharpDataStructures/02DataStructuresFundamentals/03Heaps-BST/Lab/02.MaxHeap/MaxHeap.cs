using System.Collections.Generic;

namespace _02.MaxHeap
{
    using System;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> list;

        public MaxHeap()
        {
            this.list = new List<T>();
        }

        public int Size
        {
            get { return this.list.Count; }
        }

        public void Add(T element)
        {
            this.list.Add(element);

            this.HeapifyUp(element);
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.list[0];
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("What up ?");
            }
        }

        private void HeapifyUp(T element)
        {
            int currentIndex = this.Size - 1;

            int paretnIndex = this.GetParentIndex(currentIndex);

            while (this.ValidateIndex(currentIndex)
                   && this.IsGreater(currentIndex, paretnIndex))
            {
                this.Swap(currentIndex, paretnIndex);

                currentIndex = paretnIndex;
                paretnIndex = this.GetParentIndex(currentIndex);
            }
        }

        private void Swap(
            int currentIndex,
            int paretnIndex)
        {
            var temp = this.list[currentIndex];
            this.list[currentIndex] = this.list[paretnIndex];
            this.list[paretnIndex] = temp;
        }

        private bool IsGreater(int currentIndex, int paretnIndex)
        {
            return this.list[currentIndex].CompareTo(this.list[paretnIndex]) > 0;
        }

        private bool IsLess(int currentIndex, int paretnIndex)
        {
            return this.list[currentIndex].CompareTo(this.list[paretnIndex]) < 0;
        }

        private bool ValidateIndex(int currentIndex)
        {
            return currentIndex > 0;
        }

        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

    }
}
