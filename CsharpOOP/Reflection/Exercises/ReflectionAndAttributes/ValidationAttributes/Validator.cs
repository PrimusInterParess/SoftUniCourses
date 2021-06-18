using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class  Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties= obj.GetType()
                .GetProperties();

            foreach (var prop in properties)
            {
               MyValidationAttribute[]  attributes = prop.GetCustomAttributes().Cast<MyValidationAttribute>().ToArray();

               var value= prop.GetValue(obj);

               foreach (var attribute in attributes)
               {
                  bool isValid= attribute.IsValid(value);

                  if (!isValid)
                  {
                      return false;
                  }
               }
            }

            return true;
        }
    }
}
