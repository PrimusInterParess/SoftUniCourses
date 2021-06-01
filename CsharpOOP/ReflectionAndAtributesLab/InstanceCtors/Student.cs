using System;
using System.Collections.Generic;
using System.Text;

namespace InstanceCtors
{
    public class Student
    {
        private int age = 15;
        private int averageGrade = 2;

        internal string FullName = "Pesho Peshov";

        public string NickName = "Pesho Gotinia";


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
