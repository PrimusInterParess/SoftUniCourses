using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
  public  static class Validator
    {

        public static void ThrowIfNumberIsInvalid(string number)
        {
            if (number.Any(c => !char.IsDigit(c)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
        }
    }
}
