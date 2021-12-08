using System;
using System.Collections.Generic;
using System.Text;

namespace People
{
    class Person
    {

        private string name;

        private string lastName = "Peshov";

        private int age;

        public string FullName
        {
            get { return name + " " + lastName; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
