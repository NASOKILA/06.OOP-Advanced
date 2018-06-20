using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class CommandInterpreter : ICommandInterpreter
{

    private IEnergyRepository energyRepository;
    private List<IHarvester> harvesters;
    private List<IProvider> providers;

    public CommandInterpreter(IEnergyRepository energyRepository, 
        IHarvesterController harvesterController, 
        IProviderController providerController,
        List<IHarvester> harvesters,
        List<IProvider> providers)
    {
        this.energyRepository = energyRepository;
        this.ProviderController = providerController;
        this.HarvesterController = harvesterController;

        this.harvesters = harvesters;
        this.providers = providers;   
    }
    
    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);
        return command.Execute();
    }

    private ICommand CreateCommand(IList<string> args)
    {
        var commandName = args[0];
        

        //vzimame si klasa s tova ime
        Type commandType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandName + "Command");

        //proverqvame dali go ima
        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }
        
        
        //proverqvame dali ne ICommand
        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand, commandName));
        }

        
        //vzimame konstruktura
        ConstructorInfo ctor = commandType.GetConstructors().First();

        //vzimame parametrite
        ParameterInfo[] paramsInfo = ctor.GetParameters();

        //pravim obekt s parametrite koito da mu podadem na Activatora za da napravi instanciq
        object[] parameters = new object[paramsInfo.Length];

        //pulnim masiva s parametrite
        for (int i = 0; i < paramsInfo.Length; i++)
        {
            //vzimame tipa na parametrite
            Type paramType = paramsInfo[i].ParameterType;

            //proverqbame  tiput dali e IList<string>
            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo = this.GetType().GetProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);

                parameters[i] = paramInfo.GetValue(this);
            }
            
        }

        //pravim si komandata s Activatora kato mu podavame parametrite
        ICommand currentCommand = (ICommand)Activator.CreateInstance(commandType, parameters);

        return currentCommand;
    }
}


