using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {

        public Box(List<T> list)
        {
            this.TList = list;
        }

        public List<T> TList { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.TList)
            {
                sb.AppendLine($"{item.GetType()}: {item}");

            }

            return sb.ToString().TrimEnd();

        }

        public void Swap(int firstP, int secondP)
        {

            var first = this.TList[firstP];

            this.TList[firstP] = this. TList[secondP];

            this.TList[secondP] = first;

        }

        public int CountGreaterElements( T elementToCompare)
        {
            int counter = 0;

            foreach (var element in TList)
            {
                if (elementToCompare.CompareTo(element) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
