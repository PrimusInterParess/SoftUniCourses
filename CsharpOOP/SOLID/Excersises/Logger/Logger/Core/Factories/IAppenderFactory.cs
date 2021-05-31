using SOLID.Appenders;
using SOLID.Layouts;
using SOLID.ReportLevels;

namespace SOLID.Core.Factories
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout,  ReportLevel reportLevel);
    }
}