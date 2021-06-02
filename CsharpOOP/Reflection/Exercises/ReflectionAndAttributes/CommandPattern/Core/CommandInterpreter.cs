using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandPattern.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter:ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;

        public CommandInterpreter()
        {
            this.commandFactory = new CommandFactory();
        }

        //Когато искаме да създадем отделен клас,
        //в който да изнесем част отлогиката на настоящ такъв,
        //трябва да създадем инстанция в текущия.Така новия клас върши част от работата.SOLID!!!

        public string Read(string args)
        {
            string[] parts = args.Split();

            string commandType = parts[0];
            string[] commandArgs = parts.Skip(1).ToArray();

            ICommand command = this.commandFactory.CreateCommand(commandType);

            return command.Execute(commandArgs);
        }
    }
}
