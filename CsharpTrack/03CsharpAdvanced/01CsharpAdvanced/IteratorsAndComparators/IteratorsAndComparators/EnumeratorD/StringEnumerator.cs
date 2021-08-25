using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EnumeratorD
{
    public class StringEnumerator : IEnumerator<string>
    {
        private int Index = -1;

        public StringEnumerator(string[] array)
        {
            this.Array = array;
        }

        public string[] Array { get; set; }

        public bool MoveNext()
        {
            Index++;

            if (Array.Length <= Index)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            Index =- 1;
        }

        public string Current => Array[Index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }
    }
}
