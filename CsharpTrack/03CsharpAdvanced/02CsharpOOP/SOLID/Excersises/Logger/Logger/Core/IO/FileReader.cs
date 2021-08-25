using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID.Core.IO
{
   public class FileReader:IReader
   {
       private readonly string[] fileLines;

       private int pointer;

       public FileReader(string path = "../../../input.txt")
       {
           this.fileLines = File.ReadAllLines(path);
       }

        public string ReadLine()
        {
            return this.fileLines[this.pointer++];
        }
    }
}
