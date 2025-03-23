using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] strings = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = strings[0] + "Command";

            Type commandType = Assembly.GetCallingAssembly().GetTypes().SingleOrDefault(t => t.Name == commandName);

            //if (commandType == null) return "Invalid command.";

            //if (!commandType.IsAssignableTo(typeof(ICommand)))
            //    return "Type is not a valid command.";

            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            //ICommand command;
            //try
            //{
            //    command = (ICommand)Activator.CreateInstance(commandType);
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}

            return command.Execute(strings[1..]);
        }
    }
}
