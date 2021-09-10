using System;
using System.Collections.Generic;

namespace _01.DogVet
{
    public class Owner 
    {
        public Owner(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Dogs = new SortedSet<Dog>();
            this.dogsByName = new Dictionary<string, Dog>();
        }

        public SortedSet<Dog> Dogs;
        public Dictionary<string, Dog> dogsByName;

        public string Id { get; set; }

        public string Name { get; set; }


    }
}