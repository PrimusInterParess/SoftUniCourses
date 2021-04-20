using System;
using System.Collections.Generic;
using System.Text;

namespace Ctors
{
    class FrontEndProgrammer : Programer
    {


        public FrontEndProgrammer(string name, int salary)
        : base(name, salary, new List<string> { "Java", "React" })
        {
            Console.WriteLine("In frontEnd");

        }

    
    }
}
