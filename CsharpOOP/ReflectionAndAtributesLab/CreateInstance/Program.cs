using System;
using System.Text;

namespace CreateInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Type sbType = typeof(StringBuilder);

            StringBuilder sb = (StringBuilder)Activator.CreateInstance(sbType);

            StringBuilder sbWithArgs = (StringBuilder) Activator.CreateInstance(sbType, new object[] {"Hey,Hey"});

            sbWithArgs.AppendLine("Hello! ");

            Console.WriteLine(sbWithArgs);
        }
    }
}
