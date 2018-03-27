namespace Logger.Models.Layouts
{
    using System.Globalization;
    using Contracts;
    public class XmlLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        private readonly string Format = "{ DateTime: {0}, ErrorLevel: {1}, Message: {2} }";

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