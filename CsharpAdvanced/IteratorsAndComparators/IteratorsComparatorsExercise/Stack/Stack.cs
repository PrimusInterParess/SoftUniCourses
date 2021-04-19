using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stackList;

        public Stack(params T[] data)
        {
            this.stackList = new List<T>(data.Reverse());
        }

        public T Pop()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("No elements");

            }

            var toPop = stackList[0];

            stackList.RemoveAt(0);

            return toPop;

        }

        public void Push(T item)
        {
            stackList.Insert(0, item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.stackList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
