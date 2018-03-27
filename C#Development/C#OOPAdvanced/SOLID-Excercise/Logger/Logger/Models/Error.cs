namespace Logger.Models
{
    using System;
    using Contracts;
    using Enums;

    public class Error : IError
    {
        public Error(ErrorLevel errorLevel, DateTime dateTime, string message)
        {
            this.ErrorLevel = errorLevel;
            this.DateTime = dateTime;
            this.Message = message;
        }

        public ErrorLevel ErrorLevel { get; }

        public DateTime DateTime { get; }

        public string Message { get; }
    }
}