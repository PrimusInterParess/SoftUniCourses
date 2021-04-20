using System;
using System.Collections.Generic;
using System.Text;

namespace Ctors
{
     class Programer : Employee
    {
        public Programer(string name,int salary,List<string>languages)
        :base(name,salary)
        {
            this.Languages = languages;

            Console.WriteLine("In programmer");
        }

        

        public List<string> Languages { get; set; }
    }
}
