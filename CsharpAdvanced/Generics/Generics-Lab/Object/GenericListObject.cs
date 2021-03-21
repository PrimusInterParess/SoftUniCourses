using System;
using System.Collections.Generic;
using System.Text;

namespace Object
{
    class GenericListObject
    {

        private object[] array = new object[10];

        private int index = 0;

        public void Add(object element)
        {
            array[index] = element;
            index++;

        }

        public object GetAt(int position)
        {
            return array[position];
        }
    }
}
