using System;
using System.Collections.Generic;

namespace _02.LegionSystem
{
    public class MinHeap<T>
        where T : IComparable<T>
    {
        private List<T> _list;

        public MinHeap()
        {
            _list = new List<T>();
        }

        public int Size
        {
            get { return this._list.Count; }
        }

        public List<T> List => this._list;

        public T Dequeue()
        {
            this.NotEmpty();

            T top = _list[0];
            _list[0] = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);

            HeapifyDown(0);

            return top;
        }



        public void Remove(T item)
        {
            int indexToRemove = _list.IndexOf(item);

            this._list[indexToRemove] = this._list[_list.Count - 1];
            this._list.RemoveAt(_list.Count - 1);

            this.HeapifyDown(indexToRemove);

        }

        public void Add(T element)
        {
            this._list.Add(element);

            this.HeapifyUp(element);
        }

        public T Peek()
        {
            this.NotEmpty();
            return _list[0];
        }

        private void HeapifyDown(int index)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;

            int max = left;

            if (left >= _list.Count) return;

            if (VerifyIndex(right) && IsGreater(left, right))
            {
                max = right;
            }

            if (_list[index].CompareTo(_list[max]) > 0)
            {
                T temp = _list[index];
                _list[index] = _list[max];
                _list[max] = temp;

                HeapifyDown(max);
            }
        }

        private bool IsLesser(int left, int right)
        {

            return _list[left].CompareTo(_list[right]) < 0;
        }

        private bool VerifyIndex(int index)
        {

            return (index < _list.Count);
        }

        private void HeapifyUp(T element)
        {
            int current = this.Size - 1;

            int parentIndex = this.GetParentIndex(current);

            while (this.ValidateIndex(current) &&
                   this.IsLesser(current, parentIndex))
            {
                Swap(current, parentIndex);

                current = parentIndex;
                parentIndex = this.GetParentIndex(current);
            }

        }



        private void NotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Struct is empty");
            }
        }


        private void Swap(int current, int parentIndex)
        {

            var tepm = this._list[current];
            this._list[current] = this._list[parentIndex];
            this._list[parentIndex] = tepm;
        }

        private bool IsGreater(int childeIndex, int parentIndex)
        {
            return this._list[childeIndex]
                .CompareTo(this._list[parentIndex]) > 0;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private bool ValidateIndex(int index)
        {
            return index > 0;



        }
    }
}