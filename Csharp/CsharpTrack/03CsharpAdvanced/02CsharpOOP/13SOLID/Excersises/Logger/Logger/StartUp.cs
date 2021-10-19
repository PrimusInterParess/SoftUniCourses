using System;
using System.Collections.Generic;
using SOLID.Appenders;
using SOLID.Core;
using SOLID.Core.Factories;
using SOLID.Core.IO;
using SOLID.Layouts;
using SOLID.Loggers;
using SOLID.ReportLevels;


namespace SOLID
{
    public class StartUp
    {
      

        static void Main(string[] args)
        {

            IAppenderFactory appenderFactory = new AppenderFactory();

            ILayoutFactory layoutFactory = new LayoutFactory();

            IReader reader = new FileReader();


            IEngine engine = new Engine(appenderFactory, layoutFactory, reader);

            engine.Run();
        }

      
    }

}