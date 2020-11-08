using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public CommandInterpreter()
        {
            
        }

        public string Read(string args)
        {
            var commandTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var commandName = commandTokens[0]+COMMAND_POSTFIX;
            var commandArgs = commandTokens.Skip(1).ToArray();

            var assembly = Assembly.GetCallingAssembly();
            var commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            var commandInstance = (ICommand)Activator.CreateInstance(commandType);

            var result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
