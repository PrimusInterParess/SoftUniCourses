using System;
using System.Collections.Generic;
using System.Text;

namespace Two
{
    public class Node<T>
    {

        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }
    }
}
