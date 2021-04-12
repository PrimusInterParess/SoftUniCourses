using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace simpleYieled
{
    public class MyList<T>
    {

        private T[] array;

        private int index = 0;

        public MyList()
        {
            array = new T[8];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return array[i];
            }
        }

        public void Add(T element)
        {
            array[index] = element;
        }
    }
}
