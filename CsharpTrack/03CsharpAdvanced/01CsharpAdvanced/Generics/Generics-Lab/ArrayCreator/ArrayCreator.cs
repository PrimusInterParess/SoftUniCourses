using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T defoultItem)
        {
            T[] array = new T[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = defoultItem;
            }

            return array;

        }
    }
}
