using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public static class Validator
    {

        public static void ThrowIfStringIsNullOrEmpty(string str, string exMessage)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new InvalidOperationException(exMessage);
            }
        }

        public static void ThrowIfNumberIsNegative(decimal number, string exMessage)
        {
            if (number < 0)
            {
                throw new InvalidOperationException(exMessage);
            }
        }
    }
}
