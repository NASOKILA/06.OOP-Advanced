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

            dispatcher.NameChange += handler.OnDispatcherNameChange;
            
            string command = "";
            
			while ((command = Console.ReadLine()) != "End")
            {
                dispatcher.Name = command;
            }
        }        
    }
}