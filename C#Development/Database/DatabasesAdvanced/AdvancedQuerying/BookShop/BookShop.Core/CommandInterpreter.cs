namespace BookShop.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Namespace = "BookShop.Core.Commands.";
        private const string CommandEnding = "Command";

        public IExecutable InterpretCommand(string[] commandName)
        {
            var name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName[0]) +
                       CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName[1]);

            var commandCompleteName = Namespace + name + CommandEnding;

            var command = (IExecutable)Activator.CreateInstance(Type.GetType(commandCompleteName));

            return this.InjectDependencies(command);
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            var fieldsOfCommand = command.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldsOfInterpreter = typeof(CommandInterpreter).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand.Where(f => f.GetCustomAttribute<InjectAttribute>() != null))
            {
                if (fieldsOfInterpreter.Any(x => x.FieldType == field.FieldType))
                {
                    field.SetValue(command, fieldsOfInterpreter.First(x => x.FieldType == field.FieldType)
                        .GetValue(this));
                }
            }

            return command;
        }
    }
}