using System.Collections.Generic;

namespace _03.PriorityQueue
{
    using System;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>


    {
        private List<T> Q = new List<T>();

        public PriorityQueue()
        {
            Q = new List<T>();
        }

        public int Size
        {
            get => this.Q.Count;
        }

        public T Dequeue()
        {
            var toReturn = this.Q[0];
            this.Q[0] = this.Q[this.Size - 1];
            this.Q.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return toReturn;
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = this.GetLeftChildIndex(index);

            while (this.VerifyIndexDown(leftChildIndex) &&
                   this.IsLess(index, leftChildIndex))
            {
                int toSwap = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(index);

                if (this.VerifyIndexDown(rightChildIndex) &&
                    this.IsLess(toSwap, rightChildIndex))
                {
                    toSwap = rightChildIndex;
                }

                this.Swap(toSwap, index);

                index = toSwap;
                leftChildIndex = this.GetLeftChildIndex(leftChildIndex);
            }
        }

        public void Add(T element)
        {
            this.Q.Add(element);
            this.HeapifyUp();
        }

        private void HeapifyUp()
        {
            int currentIndex = this.Size - 1;

            int parentIndex = this.GetParentIndex(currentIndex);

            while (this.VerifyIndexUp(currentIndex) &&
                   this.IsGreater(currentIndex, parentIndex))
            {
                this.Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = this.GetParentIndex(parentIndex);
            }


        }

        private bool IsGreater(int currentIndex, int parentIndex)
        {
            return this.Q[currentIndex].CompareTo(this.Q[parentIndex]) > 0;
        }


        public T Peek()
        {
            this.EnsureNotEmpty();
            return this.Q[0];
        }

        private void Swap(int index, int toSwap)
        {
            var temp = this.Q[index];
            this.Q[index] = this.Q[toSwap];
            this.Q[toSwap] = temp;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        private bool IsLess(int currentIndex, int leftChildIndex)
        {
            return this.Q[currentIndex].CompareTo(this.Q[leftChildIndex]) < 0;
        }

        private bool VerifyIndexUp(int index)
        {
            return index > 0;
        }

        private bool VerifyIndexDown(int index)
        {
            return index < this.Size;
        }

        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        public void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
