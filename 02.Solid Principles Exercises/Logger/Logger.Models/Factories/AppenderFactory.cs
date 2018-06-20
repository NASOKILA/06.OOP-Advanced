
namespace Logger.Models.Factories
{

    using System;
    using Contracts;

    public class AppenderFactory
    {
        //Za da si napravim appender ni trqbva layout
        private LayoutFactory layoutFactory;

        //trqbva ni broqch n suzdadenite appenderi
        public int fileNumber { get; private set; }

        const string defaultFileName = "logfile {0}.txt";



        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0; //pri suzdavaneto na faktorito go setvame na 0
        }

        //Suzdavame funkciq koqto suzdava appenderi
        public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            //parsvame si greshkata dali q imame v enuma
            ErrorLevel errorLevel = this.ParseErrorLevel(levelString);

            IAppender appender = null;

            //switchvame apppender tipa
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

            //this.fileNumber++;
            return appender;
        }

        //Metod za parsvane na greshki
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
