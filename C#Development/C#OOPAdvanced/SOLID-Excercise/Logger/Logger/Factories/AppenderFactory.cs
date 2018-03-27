namespace Logger.Factories
{
    using System;
    using Enums;
    using Models;
    using Models.Appenders;
    using Models.Contracts;

    public class AppenderFactory
    {
        private const string DefaultFileName = "logFile{0}.txt";

        private readonly LayoutFactory layoutFactory;
        private readonly int fileNumbers;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumbers = 0;
        }

        public IAppender CreateAppender(string appenderType, string errorLevelStr, string layoutType)
        {
            var layout = this.layoutFactory.CreateLayout(layoutType);
            var errorLevel = this.ParseErrorLevel(errorLevelStr);

            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(errorLevel, layout);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumbers));
                    appender = new FileAppender(layout, errorLevel, logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid Appender type!");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string errorLevelStr)
        {
            try
            {
                var validErrorLevel = Enum.Parse(typeof(ErrorLevel), errorLevelStr);
                return (ErrorLevel)validErrorLevel;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid ErrorLevel type!", e);
            }

        }
    }
}