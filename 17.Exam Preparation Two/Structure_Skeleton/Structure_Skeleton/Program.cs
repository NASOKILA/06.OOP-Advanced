using System.Collections.Generic;

public class Program
{

    public static void Main(string[] args)
    {

        var providers = new List<IProvider>();
        var harvesters = new List<IHarvester>();

        string mode = Modes.FullMode;
        
        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IProviderFactory providerFactory = new ProviderFactory();

        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderController providerController = new ProviderController(energyRepository, providers, providerFactory);
        IHarvesterController harvesterController = new HarvesterController(energyRepository, harvesters, harvesterFactory, mode);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(energyRepository, harvesterController, providerController, harvesters, providers);
        IWriter writer = new ConsoleWriter(); 
        IReader reader = new ConsoleReader();

        Engine engine = new Engine(writer, reader, commandInterpreter);
        engine.Run();
    }
}