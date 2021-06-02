using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public Engine()
        {

        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
