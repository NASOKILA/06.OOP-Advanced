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
        
        Type commandType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandName + "Command");

        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }
        
        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand, commandName));
        }

        ConstructorInfo ctor = commandType.GetConstructors().First();

        ParameterInfo[] paramsInfo = ctor.GetParameters();

        object[] parameters = new object[paramsInfo.Length];

        for (int i = 0; i < paramsInfo.Length; i++)
        {
            Type paramType = paramsInfo[i].ParameterType;

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

        ICommand currentCommand = (ICommand)Activator.CreateInstance(commandType, parameters);

        return currentCommand;
    }
}