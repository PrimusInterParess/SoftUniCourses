using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    interface IAbstractList<T>:IEnumerable<T>
    {

        int Count { get; }

        void Add(T item);

        void Insert(int index, T item);

        T this[int index] { get; set; }

        void RemoveAt(int index);

        bool Contains(T item);

        int IndexOf(T item);

        bool Remove(T item);


    }
}
