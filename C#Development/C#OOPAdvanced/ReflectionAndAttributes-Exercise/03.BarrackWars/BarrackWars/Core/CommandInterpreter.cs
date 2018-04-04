namespace BarrackWars.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Commands;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandEnding = "Command";
        private const string Namespace = "BarrackWars.Core.Commands.";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandCompleteName = Namespace + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandEnding;

            object[] commandParams =
             {
                data
            };

            var command = (IExecutable)Activator.CreateInstance(Type.GetType(commandCompleteName), commandParams);

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
