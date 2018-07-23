namespace Logger.Models
{
    using Contracts;
    using System;
    using System.Globalization;

    public class SimpleLayout : ILayout
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";
        const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            string formattedString = string.Format(Format, dateString, error.Level.ToString(), error.Message);

            return formattedString;
        }
    }
}