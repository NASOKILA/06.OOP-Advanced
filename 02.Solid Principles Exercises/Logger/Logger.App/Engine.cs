
namespace Logger.App
{

    using Logger.Models.Contracts;
    using Logger.Models.Factories;
    using System;

    public class Engine
    {
        //tova pole nikoga ne go izpolzvame otvun
        private ILogger logger;

        //pravim si pole za ErrorFactory zashtoto shte ni trqbva da pravene na greshki
        private ErrorFactory errorFactory;

        //inicializirame si gi ot konstruktura na engina 
        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.errorFactory = errorFactory;
            this.logger = logger;
        }

        public void Run()
        {

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {

                string[] errorArgs = input.Split('|');

                string level = errorArgs[0];
                string dateTime = errorArgs[1];
                string message = errorArgs[2];

                //suzvame si greshkata s faktorito
                IError error = errorFactory.CreateError(dateTime, level, message);

                //i q logvame chrez logera koito podadohme prez konstruktura    
                logger.Log(error);

            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }


        }

    }
}
