using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {

        private int counter = 0;
        private Dictionary<string, Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new Dictionary<string, Pet>();
        }

        public int Count
        {
            get => this.counter;
        }


        public Pet GetOldestPet()
        {
            string[] nullls = new string[1];
            Pet pet = FindPet(nullls);

            return pet;
        }
        public int Capacity { get; set; }

        public void Add(Pet pet)
        {
            string name = pet.Name;

            if (Capacity > counter)
            {
                this.counter++;
                this.pets[name] = pet;
            }


        }

        public bool Remove(string name)
        {
            if (this.pets.ContainsKey(name))
            {
                this.pets.Remove(name);
                this.counter--;
                return true;
            }

            return false;
        }

        public Pet GetPet(params string[] nameOwner)
        {
            Pet pet = FindPet(nameOwner);

            return pet;

        }

        private Pet FindPet(string[] nameOwner)
        {
            Pet pet = null;

            if (nameOwner.Length == 2)
            {
                string name = nameOwner[0];
                string owner = nameOwner[1];

                foreach (var pair in this.pets)
                {
                    if (pair.Value.Name == name && pair.Value.Owner == owner)
                    {
                        pet = pair.Value;
                        break;

                    }
                }

            }
            else
            {
                int maxAge = 0;

                foreach (var pair in this.pets)
                {
                    if (maxAge <= pair.Value.Age)
                    {
                        maxAge = pair.Value.Age;
                        pet = pair.Value;
                    }
                }
            }

            return pet;

        }

        public string GetStatistics()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Value.Name} with owner: {pet.Value.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
