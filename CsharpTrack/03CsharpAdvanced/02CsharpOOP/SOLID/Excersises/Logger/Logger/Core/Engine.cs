using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Appenders;
using SOLID.Core.Factories;
using SOLID.Core.IO;
using SOLID.Layouts;
using SOLID.Loggers;
using SOLID.ReportLevels;

namespace SOLID.Core
{
    public class Engine : IEngine
    {
        private readonly IAppenderFactory iAppenderFactory;
        private readonly ILayoutFactory iLayoutFactory;
        private readonly IReader reader;

        private ILogger logger;

        public Engine(IAppenderFactory iAppenderFactory, ILayoutFactory iLayoutFactory,IReader reader) 
        {
            this.iAppenderFactory = iAppenderFactory;
            this.iLayoutFactory = iLayoutFactory;

            this.reader = reader;
        }

        public void Run()
        {


            int n = int.Parse(this.reader.ReadLine());

            IAppender[] appenders = ReadAppenders(n);

            this.logger = new Logger(appenders);


            while (true)
            {
                string line = this.reader.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] part = line.Split('|', StringSplitOptions.RemoveEmptyEntries);

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(part[0], true);

                string date = part[1];
                string message = part[2];

                this.ProcessCommand(reportLevel, date, message);
            }

            Console.WriteLine(logger);
        }

        private void ProcessCommand(ReportLevel reportLevel, string date, string message)
        {
            switch (reportLevel)
            {
                case ReportLevel.Info:
                    this.logger.Info(date, message);
                    break;
                case ReportLevel.Warning:
                    this.logger.Warning(date, message);
                    break;
                case ReportLevel.Critical:
                    this.logger.Critical(date, message);
                    break;
                case ReportLevel.Fatal:
                    this.logger.Fatal(date, message);
                    break;
                case ReportLevel.Error:
                    this.logger.Error(date, message);
                    break;

            }
        }

        private IAppender[] ReadAppenders(int n)
        {
            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appendersParts =this.reader.ReadLine().Split();

                string appenderType = appendersParts[0];

                string layoutType = appendersParts[1];

                ReportLevel reportLevel = appendersParts.Length == 3
                    ? Enum.Parse<ReportLevel>(appendersParts[2], true)
                    : ReportLevel.Info;

                ILayout layout = this.iLayoutFactory.CreateLayout(layoutType);

                IAppender appender =
                    this.iAppenderFactory.CreateAppender(appenderType, layout, reportLevel);


                appenders[i] = appender;

            }

            return appenders;
        }
    }
}
