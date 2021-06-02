using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
  public  class CommandFactory:ICommandFactory
  {
      private const string CommandSufix = "Command";

        public ICommand CreateCommand(string commandType)
        {
          

          Type type = Assembly.GetEntryAssembly()
               .GetTypes()
               .FirstOrDefault(t => t.Name == $"{commandType}{CommandSufix}");

          if (type==null)
          {
              throw new ArgumentException($"{commandType} is invalid command type.");
          }

          ICommand instace = (ICommand)Activator.CreateInstance(type);

          return instace;

        }
    }
}
