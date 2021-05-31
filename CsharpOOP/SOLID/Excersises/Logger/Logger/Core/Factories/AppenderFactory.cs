using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Appenders;
using SOLID.Layouts;
using SOLID.Loggers;
using SOLID.ReportLevels;

namespace SOLID.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout,  ReportLevel reportLevel)
        {
            IAppender appender;

            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout,new LogFile())
                    {
                        ReportLevel = reportLevel
                    };
                    break;

                default: throw new ArgumentException($"{type} is invalid Appender type.");

            }

            return appender;
        }
    }
}
