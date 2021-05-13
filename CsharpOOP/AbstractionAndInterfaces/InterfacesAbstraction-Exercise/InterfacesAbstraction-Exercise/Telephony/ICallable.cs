using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
         string Call(string number);
    }
}
