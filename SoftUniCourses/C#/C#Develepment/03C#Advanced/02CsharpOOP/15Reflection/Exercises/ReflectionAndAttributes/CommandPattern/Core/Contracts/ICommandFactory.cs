using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Commands;

namespace CommandPattern.Core.Contracts
{
   public interface ICommandFactory
   {
       ICommand CreateCommand(string commandType);
   }
}
