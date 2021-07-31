using System;
using System.Collections.Generic;

namespace _02.Data

{
    public class MaxHeap<T>
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

        public List<T> List
        {
            get => this.list;
            private set => this.list = value;
        }

        public bool Contains(T item)
        {
            return this.list.Contains(item);
        }

        public T Dequeue()
        {
            var top = this.list[0];
            this.list[0] = this.list[list.Count - 1];
            this.list.RemoveAt(list.Count - 1);

            this.HeapifyDown(0);

            return top;

        }

        public void Remove(T item)
        {
            int indexToRemove = list.IndexOf(item);

            this.list[indexToRemove] = this.list[list.Count - 1];
            this.list.RemoveAt(list.Count - 1);

            this.HeapifyDown(indexToRemove);
        }

        public void Add(T element)
        {
            this.list.Add(element);
            this.HeapifyUp(Size - 1);
        }



        public T Peek()
        {
            this.EnsureNotEmpty();
            return this.list[0];
        }



        private void HeapifyDown(int current)
        {
            int leftChildIndex = this.GetLeftChildIndex(current);

            while (this.ValidateIndexDown(leftChildIndex) &&
                   this.IsLess(current, leftChildIndex))
            {
                int childIndex = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(current);

                if (ValidateIndexDown(rightChildIndex) &&
                    this.IsLess(childIndex, rightChildIndex))
                {
                    childIndex = rightChildIndex;
                }

                this.Swap(childIndex, current);

                current = childIndex;
                leftChildIndex = GetLeftChildIndex(leftChildIndex);
            }
        }

        private void Swap(int parentIndex, int childIndex)
        {
            var temp = this.list[parentIndex];
            this.list[parentIndex] = this.list[childIndex];
            this.list[childIndex] = temp;
        }


        private void HeapifyUp(int childIndex)
        {
            int parentIndex = this.GetParentIndex(childIndex);

            while (this.ValidateIndexUp(childIndex) &&
                   this.IsGreater(childIndex, parentIndex))
            {
                this.Swap(childIndex, parentIndex);

                childIndex = parentIndex;
                parentIndex = GetParentIndex(childIndex);
            }
        }

        private bool IsGreater(int childIndex, int parentIndex)
        {
            return this.list[childIndex].CompareTo(this.list[parentIndex]) > 0;
        }

        private bool IsLess(int index, int leftChildIndex)
        {
            return this.list[index].CompareTo(this.list[leftChildIndex]) < 0;
        }

        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private bool EnsureNotEmpty()
        {
            return this.Size == 0 ? throw new InvalidOperationException("shht") : false;
        }

        private bool ValidateIndexUp(int childIndex)
        {
            return childIndex > 0;
        }

        private bool ValidateIndexDown(int index)
        {
            return index < list.Count;
        }
    }
}