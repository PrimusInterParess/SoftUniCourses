using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;

        private int age;

        private List<Person> people;


        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(int age)
        : this("No name",age)
        {
           
            Age = age;
        }

        public Person(string name,int age )
            
        {
            this.Name = name;
            this.Age = age;

        }

        public string Name
        {
            get => this.name;

            set => this.name = value;
        }

        public int Age
        {
            get => this.age;

            set => this.age = value;

        }

    }
}
