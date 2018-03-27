namespace Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Controller;
    using Factories;
    using Models;
    using Models.Contracts;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var logger = InitializeLogger();
            var errorFactory = new ErrorFactory();
            var engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        private static ILogger InitializeLogger()
        {
            var appenders = new List<IAppender>();
            var layoutFactory = new LayoutFactory();
            var appenderFactory = new AppenderFactory(layoutFactory);

            var appenderCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < appenderCount; i++)
            {
                var cmdArgs = Console.ReadLine()
                    .Split()
                    .ToArray();

                var appenderType = cmdArgs[0];
                var layoutType = cmdArgs[1];
                var errorLevel = "Info";

                if (cmdArgs.Length == 3)
                {
                    errorLevel = cmdArgs[2];
                }

                var appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            var logger = new Logger(appenders);

            return logger;
        }
    }
}
