using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Appenders
{
    public interface IAppender
    {
        void Append(string date, string reportLevel, string message);
    }
}
