using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    class Tuple<TFirst, TSecond,TThird>
    {

        private TFirst itemFirst;

        private TSecond itemSecond;

        private TThird itemThird;

        public Tuple(TFirst item1, TSecond item2, TThird item3)
        {

            this.itemFirst = item1;

            this.itemSecond = item2;

            this.itemThird = item3;

        }


        public override string ToString()
        {

           

            return $"{this.itemFirst} -> {this.itemSecond} -> {this.itemThird}";
        }

    }
}
