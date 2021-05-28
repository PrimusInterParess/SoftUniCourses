using System;
using System.Collections.Generic;
using System.Text;
using Logger.Appenders;
using SOLID.Layouts;


namespace SOLID
{
  public  class ConsoleAppender:Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string date, string reportLevel, string message)
        {
            string content = string.Format(this.layout.Template, date, reportLevel, message);

            Console.WriteLine(content);
        }

       
    }
}
