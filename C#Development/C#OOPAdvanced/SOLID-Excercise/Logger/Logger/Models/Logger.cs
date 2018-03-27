namespace Logger.Models
{
    using System.Collections.Generic;
    using Contracts;

    public class Logger : ILogger
    {
        private readonly IEnumerable<IAppender> appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (var appender in this.appenders)
            {
                if (appender.ErrorLevel <= error.ErrorLevel)
                {
                    appender.Append(error);
                }
            }
        }
    }
}