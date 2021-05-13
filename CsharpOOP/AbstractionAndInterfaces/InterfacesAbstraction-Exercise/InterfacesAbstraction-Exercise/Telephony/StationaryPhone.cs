using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class StationaryPhone:Phone
    {
        public override string Call(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);

            return $"Dialing... {number}";
        }
    }
}
