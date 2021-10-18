using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
   public class PersonBuilder
   {
       private Person person;

       public PersonBuilder()
       {
           this.person = new Person();
       }

       public PersonBuilder WithFirstName(string firstName)
       {
           this.person.FistName = firstName;

           return this;

       }

       public PersonBuilder WithlastName(string lastName)
       {
           this.person.LastName = lastName;

           return this;
       }

       public PersonBuilder WhithAge(int age)
       {
           this.person.Age = age;

           return this;
       }

       public Person Build()
       {
           return this.person;
       }

    }
}
