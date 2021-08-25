using System.Collections.Generic;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public  class AddCollection : Addable
    {

        private List<string> list;

        public AddCollection()
        {
            this.list = new List<string>(100);
        }

        public virtual int Add(string item)  
        {

            this.list.Add(item);

            return list.IndexOf(item);

        }
    }


}