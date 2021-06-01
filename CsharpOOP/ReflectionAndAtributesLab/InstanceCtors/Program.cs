using System;
using System.Reflection;

namespace InstanceCtors
{
    class Program
    {
        static void Main(string[] args)
        {
            Type studentType = typeof(Student);

            Student student = (Student)Activator.CreateInstance(studentType, new object?[] { "Pehso Studentcheto" });


            FieldInfo[] fieldInfos= studentType.GetFields(BindingFlags.NonPublic|BindingFlags.Instance);

            foreach (var info in fieldInfos)
            {
                Console.WriteLine(info.Name);
                Console.WriteLine(info.FieldType);
                Console.WriteLine(info.IsPublic);

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Accessing private data:");

                var grade = info.GetValue(student);

                Console.WriteLine($"{info.Name} : {grade}");
            }

        

           

           
            
        }
    }
}
