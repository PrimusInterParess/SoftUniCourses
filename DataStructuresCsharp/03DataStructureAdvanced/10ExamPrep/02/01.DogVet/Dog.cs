namespace _01.DogVet
{
    using System;

    public class Dog : IComparable<Dog>
    {


        public Dog(string id, string name, Breed breed, int age, int vaccines)
        {
            this.Id = id;
            this.Name = name;
            this.Breed = breed;
            this.Age = age;
            this.Vaccines = vaccines;
        }

        public Owner Owner { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }

        public Breed Breed { get; set; }

        public int Age { get; set; }

        public int Vaccines { get; set; }


        public int CompareTo(Dog other)
        {
            int comp = this.Age.CompareTo(other.Age);

            if (comp == 0)
            {
                this.Name.CompareTo(other.Name);
            }

            if (comp==0)
            {
                this.Owner.Name.CompareTo(other.Owner.Name);
            }

            if (comp==0)
            {
               comp= this.Id.CompareTo(other.Id);
            }

            return comp;
        }
    }
}