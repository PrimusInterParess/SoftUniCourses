using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    class EQUALITYSCALE<T>
    {
        private T left;
        private T right;

        public EQUALITYSCALE(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            bool result = this.left.Equals(this.right);

            return result;

        }

    }
}
