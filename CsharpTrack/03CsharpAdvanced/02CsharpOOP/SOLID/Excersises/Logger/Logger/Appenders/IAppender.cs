using System;
using System.Collections.Generic;
using System.Text;
using SOLID.ReportLevels;

namespace SOLID.Appenders
{
   public interface IAppender
   {
       void Append(string date, ReportLevel reportLevel, string message);

       ReportLevel ReportLevel { get; set; }

   }
}
