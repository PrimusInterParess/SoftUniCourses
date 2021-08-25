using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
   public class Person
    {



        public string FistName { get;internal set; }

        public string LastName { get; internal set; }

        public int Age { get; internal set; }

        public string Gender { get; internal set; }

        public DateTime BirthDate { get; internal set; }


        public Person RegisterForExam()
        {
            return this;
        }

        public Person ParticipateInExam()
        {
            return this;
        }

        public Person CalculateScore()
        {
            return this;
        }
    }
}
