namespace Logger.Models
{
    using Contracts;
    using System;
    
    public class Error : IError
    {
        //Trqbva ni konstruktor koito ni setva poletata
        public Error(DateTime dateTime, ErrorLevel errorLevel, string message)
        {
            this.Level = errorLevel;
            this.DateTime = dateTime;
            this.Message = message;
        }

        public ErrorLevel Level { get; }

        public DateTime DateTime { get; }

        public string Message { get; }
    }
}
