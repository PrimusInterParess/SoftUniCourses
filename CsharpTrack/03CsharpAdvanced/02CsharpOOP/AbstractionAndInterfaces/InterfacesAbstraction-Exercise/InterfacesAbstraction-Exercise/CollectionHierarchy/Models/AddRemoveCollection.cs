using System.Collections.Generic;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddRemovalbe
    {
        private List<string> arr;

        public AddRemoveCollection()
        {
            this.arr = new List<string>(100);
        }

        public int Add(string item)
        {
            this.arr.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            var result = this.arr[this.arr.Count - 1];

            this.arr.RemoveAt(this.arr.Count - 1);

            return result;
        }
    }
}