namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Linq;
    using Contracts;
    using Loggers;
    using Loggers.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandHandler commandHandler;
        private readonly ILogger logger;

        public Engine()
            : this(new CommandHandler(), new ConsoleLogger())
        {
        }

        public Engine(ICommandHandler commandHandler, ILogger logger)
        {
            this.commandHandler = commandHandler;
            this.logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                var line = this.logger.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                var tokens = line
                    .Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = tokens[0];
                var parameters = tokens.Skip(1).ToArray();

                try
                {
                    var commandResult = this.commandHandler.ExecuteCommand(name, parameters);
                    this.logger.WriteLine(commandResult);
                }
                catch (Exception e)
                {
                    this.logger.WriteLine(e.Message);
                }
            }
        }
    }
}