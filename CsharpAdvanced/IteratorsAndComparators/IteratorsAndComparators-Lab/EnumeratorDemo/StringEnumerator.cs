using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EnumeratorDemo
{
    public class StringEnumerator : IEnumerator<string>
    {
        private int index = -1;

        public StringEnumerator(string[] array)
        {
            Array = array;
        }

        public string[] Array { get; set; }

        public string Current => Array[index];


        public bool MoveNext()
        {
            index++;

            if (Array.Length<=index)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            index = -1;

        }


        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
