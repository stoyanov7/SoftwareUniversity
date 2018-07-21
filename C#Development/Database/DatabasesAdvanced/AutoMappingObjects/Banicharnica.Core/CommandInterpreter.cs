namespace Banicharnica.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] input)
        {
            var commandName = input[0] + "Command";
            var tokens = input.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            var constructor = type?.GetConstructors()
                .First();

            if (type == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            var constructorParameters = constructor?.GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var service = constructorParameters?.Select(this.serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)constructor?.Invoke(service);
            var result = command?.Execute(tokens);

            return result;
        }
    }
}