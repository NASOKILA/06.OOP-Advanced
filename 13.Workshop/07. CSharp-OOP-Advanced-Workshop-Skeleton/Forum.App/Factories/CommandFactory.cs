namespace Forum.App.Factories
{
	using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
	{

        //dependency injection na service provider
        private IServiceProvider serviceProvider;

        //vmukvame go prez konstruktura
        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

		public ICommand CreateCommand(string commandName)
		{
            //pravim si faktorito s reflection


            //vzimame si assembl-to toest celiq proekt
            Assembly assembly = Assembly.GetExecutingAssembly();

            //VZIMAM MU KLASOVETE i ot tqh purviq na koito imeto mu suvpata sus commandName + "Command" !!!
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            //proverqvame dali e nameren toq klas
            if (commandType == null)
            {
                throw new ArgumentException($"{commandName}Command not found!");
            }

            //proverqvame dai klasa implementira tozi ICommand interfeis
            //ako ne e taka hvurlqme greshka
            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandName}Command is not an ICommand!");
            }

            //vzimame purviq konstruktor na vzetiq klas
            ConstructorInfo constructor = commandType.GetConstructors().First();

            //vzimame ot konstruktura parametrite
            ParameterInfo[] ctorParams = constructor
                .GetParameters();

            //pravim masiv ot obekti v koito shte slagame obekti otgovarqshti na parametrite
            object[] arguments = new object[ctorParams.Length];

            //pulnim masiva kato vzimame elementi ot service providera 
            for (int i = 0; i < arguments.Length; i++)
            {
                //vzimame servise ot suhtiq tip kato tozi na parametura na tozi index
                arguments[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            //pravim nova koanda  ot tip commandType s Activator  i mu podavame parametrite  
            //i trqbva da se kastne vseki put
            ICommand command = (ICommand)Activator
                .CreateInstance(commandType, arguments);


            //MOJEM I KATO izvikvame konstruktora DA SUZDADEM KOMANDA
            //ICommand command1 = (ICommand)constructor.Invoke(arguments);


            //factorito vrushta suzdadenata komanda
            return command;

        }
	}
}


