using ConsoleApp1;
using System;
using System.Collections;
using System.Collections.Generic;

public class List<T> : IAbstractList<T>
{
    private const int DEFAULT_CAPACITY = 4;
    private T[] _items;



    public List(int capacity = DEFAULT_CAPACITY)
    {

        if (capacity <= 0)
        {
            throw new AggregateException($"Cannot Initialize List with zaro or negative capacity!");
        }

        this._items = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            ValidateIndex(index);

            return this._items[index];


        }
        set
        {
            ValidateIndex(index);

            this._items[index] = value;
        }
    }



    public int Count
    {
        get;
        private set;

    }

    public void Add(T item)
    {
        this.CheckCapacity();

        this._items[this.Count] = item;
        this.Count++;
    }



    public bool Contains(T item)
    {
        return IndexOf(item) != -1;
    }


    public int IndexOf(T item)
    {
        

        for (int i = 0; i < this.Count; i++)
        {
            if (_items[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        this.ValidateIndex(index);

        this.CheckCapacity();

        for (int i = Count; i > index; i--)
        {
            this._items[i] = this._items[i - 1];
        }

        this._items[index] = item;
        this.Count++;
    }

    public bool Remove(T item)
    {
        int index = this.IndexOf(item);

        if (index == -1)
        {
            return false;
        }

        this.RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        ValidateIndex(index);

        for (int i = index; i < this.Count - 1; i++)
        {
            this._items[i] = this._items[i + 1];
        }

        this._items[Count - 1] = default;
        this.Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this._items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();


    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException($"Invalid index");
        }
    }

    private void CheckCapacity()
    {
        if (this._items.Length == this.Count)
        {
            this._items = Grow();
        }
    }

    private T[] Grow()
    {
        int doubleCapacity = this._items.Length * 2;

        T[] newArr = new T[doubleCapacity];

        for (int i = 0; i < Count; i++)
        {
            newArr[i] = this._items[i];
        }

        return newArr;
    }
}
