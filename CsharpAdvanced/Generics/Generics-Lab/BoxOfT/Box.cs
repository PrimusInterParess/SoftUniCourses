using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {

        private Stack<T> data;

        public Box()
        {
            this.data = new Stack<T>();
        }

        int Count
        {
            get { return data.Count; }
        }

        public T Remove()
        {
            return data.Pop();
        }

        public void Add(T item)
        {
            data.Push(item);
        }
    }
}
