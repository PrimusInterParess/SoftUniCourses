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
            this.DogsbyI = new Dictionary<string, Dog>();
            this.DogsByName = new Dictionary<string, Dog>();
            this.Dogs = new SortedSet<Dog>();
        }

        public SortedSet<Dog> Dogs;

        public Dictionary<string, Dog> DogsbyI;

        public Dictionary<string, Dog> DogsByName;

        public string Id { get; set; }

        public string Name { get; set; }


    }
}