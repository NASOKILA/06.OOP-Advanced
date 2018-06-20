namespace Logger.Models
{
    using Contracts;
    using System;
    using System.Globalization;

    public class SimpleLayout : ILayout
    {
        //error.DateTime - error.Level - error.Message
        const string DateFormat = "M/d/yyyy h:mm:ss tt";
        const string Format = "{0} - {1} - {2}";

        //vzimame greshka i q pravim na string
        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            //pravim si stringa i go vrushtame
            string formattedString = string.Format(Format, dateString, error.Level.ToString(), error.Message);

            return formattedString;
        }

    }
}
