namespace Logger.Models
{
    using Contracts;
    using System;

    public class FileAppender : IAppender
    {
        public ILogFile logFile { get; }
        public ILayout Layout { get; }
        public ErrorLevel Level { get; }

        public int MessagesAppendedCount { get; private set; }

        public FileAppender(ILayout layout, ErrorLevel reportLevel, ILogFile file)
        {
            this.Layout = layout;
            this.Level = reportLevel;
            this.logFile = file;
            this.MessagesAppendedCount = 0;
        }
        

        public void Append(IError error)
        {
            //formatira greshkata
            string errorText = this.Layout.FormatError(error);
            this.logFile.WriteToFile(errorText);
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
                $"Messages appended: {this.MessagesAppendedCount}, " +
                $"File size: {this.logFile.Size}";

            return result;
        }

    }
}
