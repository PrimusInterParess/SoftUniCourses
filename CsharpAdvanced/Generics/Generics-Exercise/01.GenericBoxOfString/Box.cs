using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {
        private List<T> values;


        public Box(List<T> values)
        {
            this.values = values;
        }

        public void Swap(int first, int second)
        {
            var temp = values[first];

            values[first] = values[second];

            values[second] = temp;

        }

        public int Count(T item)
        {

            int count = 0;

            foreach (var itm in this.values)
            {
                if (item.CompareTo(itm) < 0)
                {
                    count++;
                }

            }

            return count;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
