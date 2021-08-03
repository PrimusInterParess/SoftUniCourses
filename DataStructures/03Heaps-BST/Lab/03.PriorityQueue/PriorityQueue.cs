using System.Collections.Generic;

namespace _03.PriorityQueue
{
    using System;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {

        private List<T> priorityQ;

        public PriorityQueue()
        {
            this.priorityQ = new List<T>();
        }

        public int Size
        {
            get { return this.priorityQ.Count; }
        }

        public T Dequeue()
        {
            T top = priorityQ[0];
            priorityQ[0] = priorityQ[priorityQ.Count - 1];
            priorityQ.RemoveAt(priorityQ.Count - 1);
            this.HeapifyDown(0);

            return top;

        }

        public void Add(T element)
        {
            this.priorityQ.Add(element);

            this.HeapifyUp(element);
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.priorityQ[0];
        }

        private void HeapifyDown(int current)
        {
            int leftChildIndex = this.GetLeftChildIndex(current);

            while (this.ValidateIndexDown(leftChildIndex) &&
                   this.IsLesser(current, leftChildIndex))
            {
                int toSwap = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(current);

                if (ValidateIndexDown(rightChildIndex) &&
                    this.IsLesser(toSwap,rightChildIndex))
                {
                    toSwap = rightChildIndex;
                }

                this.Swap(toSwap,current);

                current = toSwap;
                leftChildIndex = GetLeftChildIndex(leftChildIndex);
            }

        }

        private bool IsLesser(int left, int right)
        {

            return priorityQ[left].CompareTo(priorityQ[right]) < 0;
        }

        private bool ValidateIndexDown(int right)
        {
            return (right < priorityQ.Count);
        }

        private int GetLeftChildIndex(int current)
        {
            return current * 2 + 1;
        }

        private int GetRightChildIndex(int current)
        {
            return current * 2 + 2;
        }

     

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("ooops");
            }
        }

        private void HeapifyUp(T element)
        {
            int currentIndex = this.Size - 1;

            int parentIndex = this.GetParentIndex(currentIndex);

            while (this.ValidateIndex(currentIndex) && this.IsGreater(currentIndex, parentIndex))
            {
                this.Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;

                parentIndex = this.GetParentIndex(currentIndex);

            }
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            T temp = this.priorityQ[currentIndex];
            this.priorityQ[currentIndex] = this.priorityQ[parentIndex];
            this.priorityQ[parentIndex] = temp;
        }

        private bool IsGreater(int currentIndex, int parentIndex)
        {
            return this.priorityQ[currentIndex].CompareTo(this.priorityQ[parentIndex]) > 0;
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
