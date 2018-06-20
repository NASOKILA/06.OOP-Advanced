namespace CommunicationAndEventsExe
{
    using Contracts;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            INameChangeable dispatcher = new Dispatcher("NoName");
            Handler handler = new Handler();

            //za eventa zakachame delegat kum metoda OnDispatcherNameChange
            dispatcher.NameChange += handler.OnDispatcherNameChange;
            //SEGA kogato eventa NameChange se izpulni shte se izvika metoda OnDispatcherNameChange.
 

            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                dispatcher.Name = command;
            }

        }        
    }
}
