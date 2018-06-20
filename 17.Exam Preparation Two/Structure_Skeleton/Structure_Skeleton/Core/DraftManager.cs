using System;
using System.Collections.Generic;
using System.Text;

public class DraftManager
{
        
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory harvesterFactory;
    private IProviderFactory providerFactory;

    public DraftManager()
    {
        this.mode = Modes.FullMode;
        this.totalMinedOre = 0;
        this.totalStoredEnergy = 0;
        this.energyRepository = new EnergyRepository();
       // this.harvesterController = new HarvesterController();
       // this.providerController = new ProviderController(energyRepository);
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);
        var sonicFactor = 0;
        if (arguments.Count == 5)
        {
            sonicFactor = int.Parse(arguments[4]);
        }

        try
        {
            Harvester harvester = (Harvester)this.harvesterFactory.GenerateHarvester(arguments);
            //this..Add(id, harvester);
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

        return string.Format(OutputMessages.RegisteredHarvester, type, id);
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = int.Parse(arguments[2]);

        try
        {
            Provider provider = (Provider)providerFactory.GenerateProvider(arguments);
            this.providerController.Register(arguments);
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

        return string.Format(OutputMessages.RegisteredProvider, type, id);
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];
        this.mode = mode;
        return string.Format(OutputMessages.ModeChanged, mode);
    }
    /*
    public string Inspect(List<string> arguments)
    {
        var id = arguments[0];
        var sb = new StringBuilder();
        if (this.providersById.ContainsKey(id))
        {
            sb.AppendLine(providersById[id].ToString());
        }
        if (this.harvestersById.ContainsKey(id))
        {
            sb.AppendLine(harvestersById[id].ToString());
        }
        if (string.IsNullOrWhiteSpace(sb.ToString()))
        {
            sb.AppendLine(string.Format(OutputMessages.NoElementFound, id));
        }

        return sb.ToString().Trim();
    }
    */
    public string Repair(List<string> args)
    {
        
        return "";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine(OutputMessages.ShutDown);
        sb.AppendLine(string.Format(OutputMessages.TotalEnergyProduced, this.totalStoredEnergy));
        sb.Append( string.Format(OutputMessages.TotalOreMined, this.totalMinedOre));

        return sb.ToString();
    }

}
