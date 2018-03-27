namespace Logger.Models.Layouts
{
    using System;
    using System.Globalization;
    using Contracts;

    public class JsonLayout : ILayout
    {
        private const string DateFormat = "HH:mm:ss tt";

        private readonly string Format =
            "<log>" + Environment.NewLine +
            "\t<date>{0}</date>" + Environment.NewLine +
            "\t<level>{1}</level>" + Environment.NewLine +
            "\t<message>{2}</message>" + Environment.NewLine +
            "</log>";

        public string FormatError(IError error)
        {
            var dateString = error
                .DateTime
                .ToString(DateFormat, CultureInfo.InvariantCulture);

            var formattedError = string.Format(
                this.Format, dateString, error.ErrorLevel.ToString(), error.Message);

            return formattedError;
        }
    }
}