using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;

        private List<T> list;

        public ListyIterator(params T[] data)
        {
            this.list = new List<T>(data);

            this.index = 0;

        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            Console.WriteLine(this.list[this.index]);
        }

        public bool Move()
        {
            bool hasNext = HasNext();

            if (hasNext)
            {
                index++;
            }

            return hasNext;
        }

        public bool HasNext()
        {
            return this.index < this.list.Count - 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        //private class GetCustomEnumerator : IEnumerator<T>
        //{
        //    private List<T> data;

        //    private int index;

        //    public GetCustomEnumerator(List<T> inputData)
        //    {
        //        Reset();

        //        this.data = new List<T>(inputData);
        //    }


        //    public bool MoveNext()
        //    {
        //        return ++this.index < this.data.Count;
        //    }

        //    public void Reset()
        //    {
        //        this.index = -1;
        //    }

        //    public T Current => this.data[index];

        //    object IEnumerator.Current => Current;

        //    public void Dispose()
        //    {

        //    }
        //}

    }


}
