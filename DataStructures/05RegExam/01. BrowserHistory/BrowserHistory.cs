using System.Linq;
using System.Text;

namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        // private SinglyLinkedList<ILink> links;



        private List<ILink> list;

        public BrowserHistory()
        {
            // this.links = new SinglyLinkedList<ILink>();

            list = new List<ILink>();

        }

        public int Size => this.list.Count;

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(ILink link)
        {
            return this.list.Contains(link);
        }

        public ILink DeleteFirst()
        {
            this.CheckIfEmpty();

            var toReturn = this.list[0];
            this.list.RemoveAt(0);

            return toReturn;

        }



        public ILink DeleteLast()
        {
            this.CheckIfEmpty();

            var toReturn = this.list[Size - 1];

            this.list.RemoveAt(this.Size - 1);

            return toReturn;
        }

        public ILink GetByUrl(string url)
        {
            ILink toReturn = null;


            for (int i = 0; i < Size; i++)
            {
                if (this.list[i].Url.ToLower() == url.ToLower())
                {
                    toReturn = this.list[i];
                    break;

                }
            }

            return toReturn;
        }

        public ILink LastVisited()
        {
            return this.list[Size - 1];
        }

        public void Open(ILink link)
        {

            this.list.Add(link);

        }

        public int RemoveLinks(string url)
        {
            return this.list.RemoveAll(p => p.Url.Contains(url));

        }

        public ILink[] ToArray()
        {
            var toReturn = this.list.ToArray();

            Array.Reverse(toReturn);

            return toReturn;


        }

        public List<ILink> ToList()
        {
            list.Reverse();

            return this.list;
        }

        public string ViewHistory()
        {
            if (this.list.Count == 0)
            {
                return $"Browser history is empty!";
            }

            StringBuilder sb = new StringBuilder();

            for (int a = this.Size - 1; a >= 0; a--)
            {
                sb.AppendLine(this.list[a].ToString());
            }

            return sb.ToString();
        }

        private void CheckIfEmpty()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
