using System;
using System.Reflection;
using System.Text;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Type studentType = typeof(Student);

            var interfaces = studentType.GetInterfaces();

            foreach (var typpo in interfaces)
            {
                Console.WriteLine(typpo.FullName);
                Console.WriteLine(typpo.Name);
            }

            MethodInfo[] studentMethods = studentType.GetMethods();


            foreach (var typpo in studentMethods)
            {
                Console.WriteLine(typpo.Name);
                Console.WriteLine(typpo.ReturnParameter);
            }


            return;
            Console.WriteLine("Which class do you inspect ?");
            string className = Console.ReadLine();

            Type stringBuilder = Type.GetType(className);

            //Type stringBuilder = typeof(StringBuilder);

           //Console.WriteLine(stringBuilder.Assembly );
        }
    }
}
