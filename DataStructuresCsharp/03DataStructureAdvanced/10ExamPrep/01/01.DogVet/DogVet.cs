using System;
using System.Collections.Generic;
using System.Linq;
using _01.DogVet;

namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;

    public class DogVet : IDogVet
    {
        private class DogComparer : IComparer<Dog>
        {
            public int Compare(Dog x, Dog y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return string.Compare(x.Id, y.Id, StringComparison.Ordinal);
            }
        }

        private Dictionary<string, Dog> dogsById;

        private Dictionary<string, Owner> ownersById;

        private SortedSet<Dog> dogs;

        private Dictionary<Enum, SortedSet<Dog>> breedSorted;

        private Dictionary<int, List<Dog>> byAge;

        public DogVet()
        {
            this.dogsById = new Dictionary<string, Dog>();
            this.ownersById = new Dictionary<string, Owner>();
            this.dogs = new SortedSet<Dog>(new DogComparer());
            this.breedSorted = new Dictionary<Enum, SortedSet<Dog>>();
            this.byAge = new Dictionary<int, List<Dog>>();
        }

        public int Size
        {
            get => this.dogs.Count;
        }

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.dogsById.ContainsKey(dog.Id))
                throw new ArgumentException();

            if (!this.ownersById.ContainsKey(owner.Id))
                this.ownersById.Add(owner.Id, owner);

            if (!this.breedSorted.ContainsKey(dog.Breed))
                this.breedSorted.Add(dog.Breed, new SortedSet<Dog>());

            if (!this.byAge.ContainsKey(dog.Age))
                this.byAge.Add(dog.Age, new List<Dog>());

            if (this.ownersById[owner.Id].DogsByName.ContainsKey(dog.Name))
                throw new ArgumentException();

            dog.Owner = owner;
            this.dogs.Add(dog);
            this.dogsById.Add(dog.Id, dog);
            this.ownersById[owner.Id].DogsByName.Add(dog.Name, dog);
            this.ownersById[owner.Id].Dogs.Add(dog);
            this.breedSorted[dog.Breed].Add(dog);
            this.byAge[dog.Age].Add(dog);


        }

        public bool Contains(Dog dog)
        {
            return this.dogsById.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
                throw new ArgumentException();


            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
                throw new ArgumentException();

            return this.ownersById[ownerId].DogsByName[name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
                throw new ArgumentException();


            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
                throw new ArgumentException();

            Dog toRemove = this.ownersById[ownerId].DogsByName[name];

            this.dogsById.Remove(toRemove.Id);
            this.ownersById[ownerId].DogsByName.Remove(toRemove.Name);
            this.ownersById[ownerId].Dogs.Remove(toRemove);
            this.dogs.Remove(toRemove);
            this.breedSorted[toRemove.Breed].Remove(toRemove);
            this.byAge[toRemove.Age].Remove(toRemove);

            return toRemove;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (this.ownersById.ContainsKey(ownerId))
                return this.ownersById[ownerId].Dogs;

            throw new ArgumentException();
        }



        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            if (!this.breedSorted.ContainsKey(breed))
                throw new ArgumentException();

            return this.breedSorted[breed];

        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
                throw new ArgumentException();


            if (!this.ownersById[ownerId].DogsByName.ContainsKey(name))
                throw new ArgumentException();

            this.ownersById[ownerId].DogsByName[name].Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.ownersById.ContainsKey(ownerId))
                throw new ArgumentException();


            if (!this.ownersById[ownerId].DogsByName.ContainsKey(oldName))
                throw new ArgumentException();

            Dog dog = this.ownersById[ownerId].DogsByName[oldName];
            this.ownersById[ownerId].Dogs.Remove(dog);

            dog.Name = newName;

            this.ownersById[ownerId].DogsByName.Remove(oldName);
            this.ownersById[ownerId].DogsByName.Add(dog.Name, dog);
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            if (!this.byAge.ContainsKey(age))
                throw new ArgumentException();

            return this.byAge[age];


        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            List<Dog> toReturn = new List<Dog>();

            foreach (var keyValue in byAge)
            {
                if (keyValue.Key>=lo && keyValue.Key<=hi)
                {
                    toReturn.AddRange(keyValue.Value);
                }
            }

            return toReturn;
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return this.dogs.OrderBy(d=>d.Age).ThenBy(d=>d.Name).ThenBy(d=>d.Owner.Name);
        }
    }
}