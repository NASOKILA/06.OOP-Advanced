namespace Logger.Models.Factories
{
    using Contracts;
    using System;
    using System.Globalization;

    public class ErrorFactory
    {

        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public ErrorFactory()
        {}

        public IError CreateError(string dateTimeStr, string errorLevelString, string message)
        {

            DateTime dateTime = DateTime.ParseExact(dateTimeStr, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);
            IError error = new Error(dateTime, errorLevel, message);
            
            return error;
        }


        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object validErrorLevel = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)validErrorLevel;
            }
            catch (ArgumentException e)
            {
                //vkarvame si exception v exception po gotino e !!!
                throw new ArgumentException("Invalid ErrorLevel Type!", e);
            }

        }



    }
}
