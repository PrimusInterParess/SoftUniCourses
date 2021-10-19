using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace demo
{
   public class Game : IPrintable,IEnumerable<int>
    {
        public void Print()
        {
           
        }

        public void End(bool isOver)
        {
           
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
