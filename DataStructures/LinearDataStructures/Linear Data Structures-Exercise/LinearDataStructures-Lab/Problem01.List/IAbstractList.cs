using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Problem01.List
{
    interface IAbstractList<T> : IEnumerable<T>
    {

        int Count { get; }

        T this[int index] { get; set; }

        void Add(T item);

        void Insert(int index, T item);

        bool Contains(T item);

        int IndexOf(T item);

        bool Remove(T item);

        void RemoveAt(int index);
    }
}
