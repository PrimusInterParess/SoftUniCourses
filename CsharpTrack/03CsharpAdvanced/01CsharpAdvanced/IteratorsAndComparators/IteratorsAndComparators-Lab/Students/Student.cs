using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
   public class Student:IComparable<Student>
   {

       private Random rand = new Random();

        public Student()
        {
            Name = "Pesh" + rand.Next(0, 1000000);

            Grade = rand.Next(2,7);
        }

        public string Name { get; set; }

        public double Grade { get; set; }


     

        public int CompareTo(Student other)
        {
            int result= this.Grade.CompareTo(other.Grade);

            if (result == 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return result;
        }
   }
}
