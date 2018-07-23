
namespace Logger.Models.Factories
{

    using System;
    using Contracts;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public int fileNumber { get; private set; }

        const string defaultFileName = "logfile {0}.txt";

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0; 
        }

        public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            ErrorLevel errorLevel = this.ParseErrorLevel(levelString);

            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(defaultFileName, this.fileNumber));
                    appender = new FileAppender(layout, errorLevel, logFile);
                    break;

                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

            return appender;
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
                throw new ArgumentException("Invalid ErrorLevel Type!", e);
            }         
        }
    }
}