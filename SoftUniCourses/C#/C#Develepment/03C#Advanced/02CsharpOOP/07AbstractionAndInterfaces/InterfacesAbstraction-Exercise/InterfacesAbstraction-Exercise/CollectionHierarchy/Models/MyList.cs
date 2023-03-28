using System.Collections.Generic;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList:IMylist
    {
        private List<string> listt;

        public MyList()
        {
            this.listt = new List<string>(100);
        }

        public int Add(string item)
        {
            this.listt.Insert(0, item);

            return listt.IndexOf(item);
        }

        public string Remove()
        {
            var toReturn = this.listt[0];

            this.listt.RemoveAt(0);

            return toReturn;
        }

        public int Used()
        {
            return this.listt.Count;
        }
    }
}