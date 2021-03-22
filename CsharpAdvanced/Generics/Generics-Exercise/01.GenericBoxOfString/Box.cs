using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {
<<<<<<< HEAD
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
=======

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
>>>>>>> aa55df6124baaed060968785d44dc2aa03ed3e4a
        }
    }
}
