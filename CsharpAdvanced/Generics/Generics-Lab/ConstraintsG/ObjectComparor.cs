using System;
using System.Collections.Generic;
using System.Text;

namespace ConstraintsG
{
    class ObjectComparor<TFirst, TSecond>
    where TFirst : IComparable
    where TSecond : IComparable
    {

        public bool IsFirstBigger(TFirst firstObj, TSecond secondObj)
        {
            int result = firstObj.CompareTo(secondObj);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
