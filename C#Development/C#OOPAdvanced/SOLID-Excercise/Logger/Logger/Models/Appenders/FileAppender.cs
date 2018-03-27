namespace Logger.Models.Appenders
{
    using Contracts;
    using Enums;

    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }

        public ErrorLevel ErrorLevel { get; }

        public ILayout Layout { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            var appenderType = this.GetType().Name;
            var layoutType = this.Layout.GetType().Name;
            var errorLevel = this.ErrorLevel.ToString();
            var result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {errorLevel}, Messages apended: {this.MessagesAppended}, File size: {this.logFile.Size}";

            return result;
        }
    }
}