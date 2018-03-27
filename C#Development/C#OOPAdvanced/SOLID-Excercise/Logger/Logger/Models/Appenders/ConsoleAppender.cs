namespace Logger.Models.Appenders
{
    using System;
    using Contracts;
    using Enums;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ErrorLevel errorLevel, ILayout layout)
        {
            this.ErrorLevel = errorLevel;
            this.Layout = layout;
            this.MessagesAppended = 0;
        }

        public ErrorLevel ErrorLevel { get; }

        public ILayout Layout { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var formatError = this.Layout.FormatError(error);
            Console.WriteLine(formatError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            var appenderType = this.GetType().Name;
            var layoutType = this.Layout.GetType().Name;
            var errorLevel = this.ErrorLevel.ToString();
            var result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {errorLevel}, Messages apended: {this.MessagesAppended}";

            return result;
        }
    }
}