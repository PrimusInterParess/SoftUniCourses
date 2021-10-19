using System;
using System.Collections.Generic;
using System.Text;

namespace GG
{
    public class MyList<T>
        where T : Animal

    {

    private Stack<T> data;

    public MyList()
    {
        this.data = new Stack<T>();
    }

    public int Count
    {
        get { return this.data.Count; }
    }

    public void Add(T item)
    {
        data.Push(item);
    }

    public T Remove()
    {
        return data.Pop();
    }


    }
}
