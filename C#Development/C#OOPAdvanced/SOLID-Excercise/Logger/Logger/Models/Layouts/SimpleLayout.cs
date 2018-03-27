namespace Logger.Models.Layouts
{
    using System.Globalization;
    using Contracts;

    public class SimpleLayout : ILayout
    {
        // error.DateTime - error.ErrorLevel - error.Message
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";
        private const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            var dateString = error
                .DateTime
                .ToString(DateFormat, CultureInfo.InvariantCulture);

            var formattedError = string.Format(
                Format, dateString, error.ErrorLevel.ToString(), error.Message);

            return formattedError;
        }
    }
}