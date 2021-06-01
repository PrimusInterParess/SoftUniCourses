using System;
using System.Collections.Generic;
using System.Text;

namespace GettingCtors
{
   public class Student
    {

        public Student()
        {

        }

        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
