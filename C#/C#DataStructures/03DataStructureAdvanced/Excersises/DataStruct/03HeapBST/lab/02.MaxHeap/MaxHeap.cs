using System.Collections.Generic;

namespace _02.MaxHeap
{
    using System;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap()
        {
            this.heap = new List<T>();
        }

        public int Size
        {
            get => this.heap.Count;
        }

        public void Add(T element)
        {
            this.heap.Add(element);
            this.heapifyUp(element);
        }


        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.heap[0];
        }

        private void heapifyUp(T element)
        {
            int currentIndex = this.Size - 1;

            int parentIndex = this.GetParentIndex(currentIndex);

            while (this.ValidateIndex(currentIndex)
                   && this.IsGreater(currentIndex, parentIndex))
            {
                this.Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = this.GetParentIndex(parentIndex);
            }

        }

        public void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            var temp = this.heap[currentIndex];
            this.heap[currentIndex] = this.heap[parentIndex];
            this.heap[parentIndex] = temp;
        }

        private bool IsGreater(int currentIndex, int parentIndex)
        {
            return this.heap[currentIndex].CompareTo(this.heap[parentIndex]) > 0;
        }

        private bool ValidateIndex(int currentIndex)
        {
            return currentIndex > 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}
