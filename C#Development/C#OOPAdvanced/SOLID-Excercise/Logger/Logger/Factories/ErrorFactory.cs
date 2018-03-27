namespace Logger.Factories
{
    using System;
    using System.Globalization;
    using Enums;
    using Models;
    using Models.Contracts;

    public class ErrorFactory
    {
        private const string DateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError CreatError(string dateTimeStr, string errorLevelStr, string message)
        {
            var dateTime = DateTime.ParseExact(dateTimeStr, DateFormat, CultureInfo.InvariantCulture);
            var errorLevel = this.ParseErrorLevel(errorLevelStr);
            var error = new Error(errorLevel, dateTime, message);

            return error;
        }

        // TODO: Extract to Common class
        private ErrorLevel ParseErrorLevel(string errorLevelStr)
        {
            try
            {
                var errorLevelObj = Enum.Parse(typeof(ErrorLevel), errorLevelStr);
                return (ErrorLevel) errorLevelObj;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid ErrorLevel type!", e);
            }
        }
    }
}