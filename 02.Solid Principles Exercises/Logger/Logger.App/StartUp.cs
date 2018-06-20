namespace Logger.App
{
    using Logger.Models.Contracts;
    using System;
    using Logger.Models;
    using System.Collections.Generic;
    using Logger.Models.Factories;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //purvo si pravim loggera
            ILogger logger = InitializeLogger();
            
            //pravim si i fatory za greshki
            ErrorFactory errorFactory = new ErrorFactory();

            //podavame gi na engina
            Engine engine = new Engine(logger, errorFactory);

            //puskame engina s metoda Run()
            engine.Run();   

        }

        //Inicializirame loggera
        static ILogger InitializeLogger()
        {
            //pravim si kolekciq s apenderi
            ICollection<IAppender> appenders = new List<IAppender>();

            //suzdavame si layoutFactory 
            LayoutFactory layoutFactory = new LayoutFactory();
            
            //i appenderFactory
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);
            
            //VIJDAME CHE EDNOTO FAKTORY POLZVA DRUGOTO
            

            //chetem si chisloto ot konzolata i si suzdavame appenderite
            int appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                //vzimame si inputa
                string[] args = Console.ReadLine().Split();

                string appenderType = args[0];
                string layoutType = args[1];
                string errorLevel = "INFO";
                
                //ako imame 3 elementa v inputa znachi imame i podadn tip greshka
                if (args.Length == 3)
                    errorLevel = args[2];
                
                //suzdavame si appender polzvaiki faktorito
                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            //pravim si loggera i go vrushtame
            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}

