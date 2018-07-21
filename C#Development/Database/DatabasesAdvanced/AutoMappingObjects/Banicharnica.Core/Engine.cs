namespace Banicharnica.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var initializeDb = this.serviceProvider
                .GetService<IDbInitializerService>();

            initializeDb.InitializeDatabase();

            var commandInterpreter = this.serviceProvider
                .GetService<ICommandInterpreter>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var result = commandInterpreter.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
