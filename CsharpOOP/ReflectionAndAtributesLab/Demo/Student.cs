using System;

namespace Demo
{
    public class Student:ICloneable,IComparable

    {
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public void Hello()
        {

        }
    }
}