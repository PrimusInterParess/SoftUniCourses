using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace onToTheNexOne
{
    public class Game :IPrintable,IEnumerable<int>
    {
        public void Print()
        {
            throw new NotImplementedException();
        }

        public void End(bool isOver)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
