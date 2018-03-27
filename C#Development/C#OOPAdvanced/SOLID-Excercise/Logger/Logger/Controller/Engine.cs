namespace Logger.Controller
{
    using System;
    using Factories;
    using Models.Contracts;

    public class Engine
    {
        private readonly ILogger logger;
        private readonly ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var errorArgs = input.Split("|");
                var errorLevel = errorArgs[0];
                var dateTime = errorArgs[1];
                var message = errorArgs[2];

                var error = this.errorFactory.CreatError(dateTime, errorLevel, message);
                this.logger.Log(error);
            }

            Console.WriteLine("Logger info:");
            foreach (var appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}