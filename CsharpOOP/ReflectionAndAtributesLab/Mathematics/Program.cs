using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MathsSoftUni);

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static);


            foreach (var method in methods)
            {
                var methodParams = method.GetParameters().Select(p=>new KeyValuePair<string,string>(p.Name,p.ParameterType.Name));
                Console.WriteLine($"{method.Name} => {string.Join(", ", methodParams)}");
            }
        }
    }
}
