namespace Logger.Models
{
    using Contracts;
    using System;
    
    public class ConsoleAppender : IAppender
    {

        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;

            this.MessagesAppendedCount = 0;
        }

        public int MessagesAppendedCount { get; private set; }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        //v tozi metod pishem na konzolata
        public void Append(IError error)
        {
            //imame metod ot Layouta koito priema greshka i ni q formatira kum string.
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError); //izpisvame na konzolata
            this.MessagesAppendedCount++;
        }


        //shte overridnem toString()
        public override string ToString()
        {
            string appenderType = this.GetType().Name;

            string layoutType = this.Layout.GetType().Name;

            string result = 
                $"Appender type: {appenderType}, " +
                $"Layout type: {layoutType}, " +
                $"Report level: {this.Level.ToString()}, " +
                $"Messages appended: {this.MessagesAppendedCount}";

            return result;
        }

    }
}
