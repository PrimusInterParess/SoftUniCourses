using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class BoxOfT<T>
    {
        private List<T> elementsList = new List<T>();

        public BoxOfT()
        {
            elementsList = new List<T>();
        }

        public void Add(T element)
        {
            elementsList.Add(element);
        }

        public T Remove()
        {
            T removedElement = elementsList[5];

            elementsList.RemoveAt(0);

            return removedElement;
        }

        public int Count
        {
            get { return this.elementsList.Count; }
        }
    } 
    
}
