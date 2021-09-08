using System.Linq;
using System.Runtime.InteropServices;

namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;



    public class DogVet : IDogVet
    {

        private Dictionary<string, Owner> ownersById;
        private SortedSet<Dog> dogsInVet;
        private Dictionary<Enum, SortedSet<Dog>> dogsByBreed;
        private Dictionary<int, SortedSet<Dog>> byAge;
        private SortedSet<Dog> rangeOrdered;

        public DogVet()
        {
            this.ownersById = new Dictionary<string, Owner>();
            this.dogsInVet = new SortedSet<Dog>();
            this.dogsByBreed = new Dictionary<Enum, SortedSet<Dog>>();
            this.byAge = new Dictionary<int, SortedSet<Dog>>();
            this.rangeOrdered = new SortedSet<Dog>();
        }

        public int Size
        {
            get => this.dogsInVet.Count;
        }

        public void AddDog(Dog dog, Owner owner)
        {
            if (!this.ownersById.ContainsKey(owner.Id))
            {
                this.ownersById.Add(owner.Id, owner);
            }

            if (ownersById[owner.Id].DogsbyI.ContainsKey(dog.Id) &&
                ownersById[owner.Id].DogsByName.ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            dog.Owner = owner;

            this.rangeOrdered.Add(dog);

            this.ownersById[owner.Id].DogsbyI.Add(dog.Id, dog);

            this.ownersById[owner.Id].DogsByName.Add(dog.Name, dog);

            if (!this.ownersById[owner.Id].Dogs.Contains(dog))
            {
                this.ownersById[owner.Id].Dogs.Add(dog);

            }

            if (!this.dogsByBreed.ContainsKey(dog.Breed))
            {
                this.dogsByBreed.Add(dog.Breed, new SortedSet<Dog>());
            }

            this.dogsByBreed[dog.Breed].Add(dog);

            if (!this.dogsInVet.Contains(dog))
            {
                this.dogsInVet.Add(dog);
            }

            if (!this.byAge.ContainsKey(dog.Age))
            {
                this.byAge.Add(dog.Age, new SortedSet<Dog>());
            }

            this.byAge[dog.Age].Add(dog);

        }

        public bool Contains(Dog dog)
        {
            return this.dogsInVet.Contains(dog);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            return this.ownersById[ownerId].DogsByName[name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Dog toRemove = this.ownersById[ownerId].DogsByName[name];

            this.dogsInVet.Remove(toRemove);

            this.byAge[toRemove.Age].Remove(toRemove);

            this.ownersById[ownerId].DogsbyI.Remove(toRemove.Id);

            this.ownersById[ownerId].DogsByName.Remove(name);

            this.ownersById[ownerId].Dogs.Remove(toRemove);

            this.dogsByBreed[toRemove.Breed].Remove(toRemove);

            this.rangeOrdered.Remove(toRemove);

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
            if (!this.dogsByBreed.ContainsKey(breed))
            {
                throw new ArgumentException();
            }

            if (this.dogsByBreed[breed].Count == 0)
            {
                throw new ArgumentException();
            }

            return this.dogsByBreed[breed];
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            this.ownersById[ownerId].DogsByName[name].Vaccines++;
            //????????????????????????????????????????????????????????

        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.ownersById[ownerId].DogsByName.ContainsKey(oldName))
            {
                throw new ArgumentException();
            }

            this.ownersById[ownerId].DogsByName[oldName].Name = newName;

            var value = this.ownersById[ownerId].DogsByName[oldName];

            this.ownersById[ownerId].DogsByName.Remove(oldName);

            this.ownersById[ownerId].DogsByName.Add(value.Name, value);
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            if (!this.byAge.ContainsKey(age))
            {
                throw new ArgumentException();
            }

            return this.byAge[age];
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            SortedSet<Dog> result = new SortedSet<Dog>();
            foreach (var dog in dogsInVet)
            {
                if (dog.Age >= lo && dog.Age <= hi)
                {
                    result.Add(dog);
                }
            }


            return result;
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return this.dogsInVet;
        }
    }
}