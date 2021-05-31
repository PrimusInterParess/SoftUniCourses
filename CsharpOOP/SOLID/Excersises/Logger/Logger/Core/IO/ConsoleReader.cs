using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Core.IO
{
   public class ConsoleReader: IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
