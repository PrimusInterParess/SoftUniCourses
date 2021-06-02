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

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            MathsSoftUni math = new MathsSoftUni();

            foreach (var method in methods)
            {
                ParameterInfo[] methodParamInfo = method.GetParameters();

                var methodParams = methodParamInfo.Select(p => new KeyValuePair<string, string>(p.Name, p.ParameterType.Name));
                Console.WriteLine($"{method.Name} => {string.Join(", ", methodParams)}");


                var inputParams = new object[] { 5, 6 };

                if (methodParamInfo.Length > 2)
                {
                    inputParams = new object[] {5, 6, 7};

                }

                int res = (int)method.Invoke(math, inputParams);
                // слагаш параметри и изивикваш метода върху инстанцияата "math"

                Console.WriteLine(res);
            }


        }
    }
}
