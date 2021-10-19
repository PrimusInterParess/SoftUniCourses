using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{

        //може да конкретизираме върху какво да работи атрибута
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
    class StudentAttribute:Attribute
    {
        //може да има конструктори,пропъртита... Виж клас "Student"
        //поведение като абстрактен клас

        public StudentAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }


    }
}
