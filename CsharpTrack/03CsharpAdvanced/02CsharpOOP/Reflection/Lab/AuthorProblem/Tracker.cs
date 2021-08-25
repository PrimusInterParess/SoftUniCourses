using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        [Author("GoshoKelesha")]
        public void PrintMethodByAuthor()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t=>t==typeof(StartUp)).ToArray();

            foreach (var typ in allTypes)
            {

                PrintALlMethodsAuthors(typ);
                continue;
                if (!typ.GetCustomAttributes().Any(t=>t.GetType()==typeof(AuthorAttribute)))
                {
                    continue;
                }

                AuthorAttribute[] attributes = typ
                    .GetCustomAttributes()
                    .Where(t=>t.GetType()==typeof(AuthorAttribute))
                    .Select(t=>(AuthorAttribute)t)
                    .ToArray();

                foreach (var atr in attributes)
                {
                    Console.WriteLine($"{typ.Name} created by {atr.Name}");
                }
            }
        }

        private void PrintALlMethodsAuthors(Type typ)
        {
            MethodInfo[] methods = typ.GetMethods(BindingFlags.Public|
                                                  BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance);

            foreach (var meth in methods)
            {
                if (!meth.GetCustomAttributes().Any(a => a.GetType() == typeof(AuthorAttribute)))
                {
                    continue;
                }

                List<Attribute> atriAttribute = meth.GetCustomAttributes().ToList();

                foreach (var atrAttribute in atriAttribute)
                {
                    if (atrAttribute is AuthorAttribute)
                    {
                        AuthorAttribute author = (AuthorAttribute)atrAttribute;
                        Console.WriteLine($"{meth.Name} is written by {author.Name}");
                    }
                }

            }

        }
    }
}
