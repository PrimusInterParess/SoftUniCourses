using Wintellect.PowerCollections;

namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;

    public class PersonCollection : IPersonCollection
    {
        private Dictionary<string, Person> byEmail;
        private Dictionary<string, SortedSet<Person>> byDomain;
        private Dictionary<string, SortedSet<Person>> byNameAndTown;
        private OrderedDictionary<int, SortedSet<Person>> byAge;
        private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> byTownAndAge;

        public PersonCollection()
        {
            this.byEmail = new Dictionary<string, Person>();
            this.byDomain = new Dictionary<string, SortedSet<Person>>();
            this.byNameAndTown = new Dictionary<string, SortedSet<Person>>();
            this.byAge = new OrderedDictionary<int, SortedSet<Person>>();
            this.byTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            Person person = new Person()
            {
                Name = name,
                Email = email,
                Age = age,
                Town = town
            };

            if (this.byEmail.ContainsKey(email))
            {
                return false;
            }

            this.byEmail.Add(email, person);

            string host = person.Email.Substring(person.Email.IndexOf('@') + 1);

            if (!this.byDomain.ContainsKey(host))
            {
                this.byDomain.Add(host, new SortedSet<Person>());
            }

            this.byDomain[host].Add(person);

            string nameTown = name + " " + town;

            if (!this.byNameAndTown.ContainsKey(nameTown))
            {
                this.byNameAndTown.Add(nameTown, new SortedSet<Person>());
            }

            this.byNameAndTown[nameTown].Add(person);

            if (!this.byAge.ContainsKey(age))
            {
                this.byAge.Add(age, new SortedSet<Person>());
            }

            this.byAge[age].Add(person);

            if (!this.byTownAndAge.ContainsKey(town))
            {
                this.byTownAndAge.Add(town, new OrderedDictionary<int, SortedSet<Person>>());
            }

            if (!this.byTownAndAge[town].ContainsKey(age))
            {
                this.byTownAndAge[town].Add(age, new SortedSet<Person>());
            }

            this.byTownAndAge[town][age].Add(person);

            return true;
        }

        public int Count
        {
            get => this.byEmail.Count;
        }
        public Person FindPerson(string email)
        {
            if (!this.byEmail.ContainsKey(email))
            {
                return null;
            }

            return this.byEmail[email];
        }

        public bool DeletePerson(string email)
        {
            if (!this.byEmail.ContainsKey(email))
            {
                return false;
            }

            Person toRemove = this.byEmail[email];

            this.byEmail.Remove(email);

            string host = toRemove.Email.Substring(toRemove.Email.IndexOf('@') + 1);

            this.byDomain.Remove(host);

            this.byNameAndTown[toRemove.Name + " " + toRemove.Town].Remove(toRemove);

            this.byAge[toRemove.Age].Remove(toRemove);

            this.byTownAndAge[toRemove.Town][toRemove.Age].Remove(toRemove);

            return true;

        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.byDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return this.byNameAndTown.GetValuesForKey(name + " " + town);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {

            List<Person> toReturn = new List<Person>();
            foreach (var key in byAge)
            {
                if (key.Key >= startAge && key.Key <= endAge)
                {
                    toReturn.AddRange(key.Value);
                }
            }

            return toReturn;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            List<Person> toReturn = new List<Person>();

            if (byTownAndAge.ContainsKey(town))
            {
                foreach (var collection in byTownAndAge[town])
                {
                    if (collection.Key >= startAge && collection.Key <= endAge)
                    {
                        toReturn.AddRange(collection.Value);
                    }
                }
            }


            return toReturn;
        }
    }
}
