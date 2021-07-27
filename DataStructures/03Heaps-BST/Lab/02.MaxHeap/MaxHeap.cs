using System.Collections.Generic;

namespace _02.MaxHeap
{
    using System;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _maxHeap;

        public MaxHeap()
        {
            this._maxHeap = new List<T>();
        }

        public int Size
        {
            get { return this._maxHeap.Count; }
        }

        public void Add(T element)
        {
            this._maxHeap.Add(element);

            this.HeapifyUp(element);
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._maxHeap[0];
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("ex");
            }
        }

        private void HeapifyUp(T element)
        {
            int currentIndex = this.Size - 1;

            int parentIndex = this.GetParentIndex(currentIndex);

            while (this.ValideteCurrentIndex(currentIndex) &&
                   this.IsGreater(currentIndex, parentIndex))
            {
                this.Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = this.GetParentIndex(currentIndex);
            }
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            var temp = _maxHeap[currentIndex];
            _maxHeap[currentIndex] = _maxHeap[parentIndex];
            _maxHeap[parentIndex] = temp;
        }

        private bool IsGreater(int currentIndex, int parentIndex)
        {
            return this._maxHeap[currentIndex].CompareTo(this._maxHeap[parentIndex]) > 0;
        }

        private bool ValideteCurrentIndex(int currentIndex)
        {
            return currentIndex > 0;
        }

        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;

        }
    }
}
