using System;
using System.Collections.Generic;
using System.Reflection;

namespace _02.FitGym
{
    public class Trainer : IComparable<Trainer>
    {
        public Trainer(int id, string name, int popularity)
        {
            this.Id = id;
            this.Name = name;
            this.Popularity = popularity;
            this.Members=new HashSet<Member>();
        }

        public HashSet<Member> Members;

        public int Id { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public int CompareTo(Trainer other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}