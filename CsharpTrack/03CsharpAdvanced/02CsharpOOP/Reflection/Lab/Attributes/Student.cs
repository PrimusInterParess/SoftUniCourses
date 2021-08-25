using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    [Serializable]
    [Obsolete]
    [Student(name:"Pesho")]//-> тук задаваш параметъра който трябва,може и от конзолата.

    class Student
    {
        [Obsolete]
        public void PrintName()
        {

        }
    }
}
