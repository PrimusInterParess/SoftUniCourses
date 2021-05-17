using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class SmartPhone : Phone,IBrowsable
    {
        public override string Call(string number)
        {
           Validator.ThrowIfNumberIsInvalid(number);

            return $"Calling... {number}";
        }


        public string Browse(string url)
        {
            if (url.Any(x=>char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }
    }
}
