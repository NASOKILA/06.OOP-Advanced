namespace Logger.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class Logger : ILogger
    {
        //CELATA E VSICHKO DA E POD NAKAKUV INTERFEIS !!!
        
        //spisuk s appenderi
        private ICollection<IAppender> appenders;

        
        /*
        //toq konstruktor ne go polzvame
        public Logger(IAppender appender)
        {
            this.appenders = new List<IAppender>();
            this.appenders.Add(appender);
        }
        */

        //podavame spisuk koito go setvame na nashiq 'appenders'
        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        //s tova samo gi gledame i vzimame ot vun klasa NO NE MOJEM DA GI PROMENQME
        //Direktno si go kastvame
        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        //Metod koito priema IError kato parametur
        public void Log(IError error)
        {
            //za vseki appender v nashata kolekciq s appenderi
            foreach (IAppender appender in this.Appenders)
            {
                //ako nivoto na greshtaka e > ot tova na tekushtiq appendera 
                if (appender.Level <= error.Level)
                {
                    //appendvame greshkata za tekushtiq apender
                    appender.Append(error);
                }
            }
        }


        //metod za dobavka na appender
        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

    }

}