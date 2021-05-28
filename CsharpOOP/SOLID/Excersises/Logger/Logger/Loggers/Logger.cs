using System;
using System.Collections.Generic;
using System.Text;
using Logger.Appenders;
using SOLID.Appenders;
using SOLID.Loggers;

namespace SOLID
{
   public  class Logger:ILogger
   {
       private IAppender appender;

       public Logger(IAppender appender)
       {
           this.appender = appender;
       }

       public void Info(string date, string message)
       {
           this.appender.Append(date,"Info",message);
       }

       public void Error(string date, string message)
       {
           this.appender.Append(date, "Error", message);
        }
   }
}

