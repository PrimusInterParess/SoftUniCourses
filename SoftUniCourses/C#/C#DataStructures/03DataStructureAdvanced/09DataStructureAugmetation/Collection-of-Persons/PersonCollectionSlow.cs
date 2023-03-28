using System.Linq;

namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;

    public class PersonCollectionSlow : IPersonCollection
    {
        // TODO: define the underlying data structures here ...

        private List<Person> people;

        public PersonCollectionSlow()
        {
            this.people = new List<Person>();
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

            foreach (var human in people)
            {
                if (human.Email == email)
                {
                    return false;
                }
            }

            this.people.Add(person);
            return true;
        }

        public int Count
        {
            get => this.people.Count;
        }
        public Person FindPerson(string email)
        {

            foreach (var person in people)
            {
                if (person.Email == email)
                {
                    return person;
                }
            }

            return null;
        }

        public bool DeletePerson(string email)
        {

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Email == email)
                {
                    people.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            List<Person> toReturn = new List<Person>();

            foreach (var person in people)
            {
                string host = person.Email.Substring(person.Email.IndexOf('@') + 1);

                if (host == emailDomain)
                {
                    toReturn.Add(person);
                }
            }

            return toReturn.OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {

            List<Person> toReturn = new List<Person>();

            foreach (var person in people)
            {

                if (person.Name == name && person.Town == town)
                {
                    toReturn.Add(person);
                }
            }

            return toReturn.OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            List<Person> toReturn = new List<Person>();

            foreach (var person in people)
            {

                if (person.Age >= startAge && person.Age <= endAge)
                {
                    toReturn.Add(person);
                }
            }

            return toReturn.OrderBy(p => p.Age).ThenBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            List<Person> toReturn = new List<Person>();

            foreach (var person in people)
            {

                if (person.Age >= startAge && person.Age <= endAge && person.Town==town)
                {
                    toReturn.Add(person);
                }
            }

            return toReturn.OrderBy(p => p.Age).ThenBy(p => p.Email);
        }
    }
}
