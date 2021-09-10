using System.Linq;
using System.Runtime.InteropServices;

namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;



    public class DogVet : IDogVet
    {
        private Dictionary<string, Owner> ownersById;
        private Dictionary<string, Dog> vetClinic;
        private Dictionary<Enum, SortedSet<Dog>> byBreed;
        private HashSet<Dog> ageSorted;

        public DogVet()
        {
            this.ownersById = new Dictionary<string, Owner>();
            this.vetClinic = new Dictionary<string, Dog>();
            this.ageSorted = new HashSet<Dog>();
            this.byBreed = new Dictionary<Enum, SortedSet<Dog>>();
        }

        public int Size
        {
            get => this.vetClinic.Count;
        }

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.vetClinic.ContainsKey(dog.Id))
            {
                throw new ArgumentException();
            }

            if (!this.byBreed.ContainsKey(dog.Breed))
            {
                this.byBreed.Add(dog.Breed,new SortedSet<Dog>());
            }

            if (!this.ownersById.ContainsKey(owner.Id))
            {
                this.ownersById.Add(owner.Id, owner);
            }

            if (this.ownersById[owner.Id].dogsByName.ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            dog.Owner = owner;


            this.vetClinic[dog.Id] = dog;
            this.ageSorted.Add(dog);

            this.byBreed[dog.Breed].Add(dog);
            this.ownersById[owner.Id].dogsByName.Add(dog.Name, dog);
            this.ownersById[owner.Id].Dogs.Add(dog);

        }

        public bool Contains(Dog dog)
        {
            return this.vetClinic[dog.Id] == dog;
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.ownersById[ownerId].dogsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            return this.ownersById[ownerId].dogsByName[name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.ownersById[ownerId].dogsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Dog toRemove = this.ownersById[ownerId].dogsByName[name];

            this.ownersById[ownerId].dogsByName.Remove(name);
            this.ownersById[ownerId].Dogs.Remove(toRemove);
            this.vetClinic.Remove(toRemove.Id);
            this.ageSorted.Remove(toRemove);
            this.byBreed[toRemove.Breed].Remove(toRemove);

            return toRemove;

        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            return this.ownersById[ownerId].Dogs;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            if (!this.byBreed.ContainsKey(breed))
            {
                throw new ArgumentException();
            }

            return this.byBreed[breed];
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.ownersById[ownerId].dogsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            this.ownersById[ownerId].dogsByName[name].Vaccines++;
            //????????????????????????????????????????????????????????

        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.ownersById[ownerId].dogsByName.ContainsKey(oldName))
            {
                throw new ArgumentException();
            }

            this.ownersById[ownerId].dogsByName[oldName].Name = newName;

            var value = this.ownersById[ownerId].dogsByName[oldName];

            this.ownersById[ownerId].dogsByName.Remove(oldName);

            this.ownersById[ownerId].dogsByName.Add(value.Name, value);
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            return this.ageSorted.Where(d => d.Age == age);
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            return this.ageSorted.Where(d => d.Age >= lo && d.Age <= hi);
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return this.ageSorted;
        }
    }
}