using System;
using System.Reflection;

namespace GettingCtors
{
    class Program
    {
        static void Main(string[] args)
        {
            Type typeOfStudent = typeof(Student);

            ConstructorInfo[] constructors = typeOfStudent.GetConstructors();

            ConstructorInfo ctor = typeOfStudent.GetConstructor(new Type[] {typeof(string), typeof(int)});

            foreach (var ctor in constructors)
            {
               ParameterInfo[] paramInfos= ctor.GetParameters();
            }
        }
    }
}
