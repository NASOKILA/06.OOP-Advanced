using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    private IEnergyRepository energyRepository;
    private IList<IHarvester> harvesters;
    private IHarvesterFactory factory;
    private string mode;
    
    public HarvesterController(
        IEnergyRepository energyRepository, 
        IList<IHarvester> harvesters,   
        IHarvesterFactory factory, 
        string mode)
    {
        this.energyRepository = energyRepository;
        this.harvesters = harvesters;
        this.factory = factory;
        this.mode = mode;   
        this.OreProduced = 0;
    }

    public double OreProduced { get; private set; }

    public IList<IHarvester> Entities => this.harvesters;

    public string ChangeMode(string mode)
    {
        IList<IHarvester> reminder = new List<IHarvester>();
        //Ako edinharvester se schupi shte hvurli exeption sledovatelno shte go premahnem

        foreach (var har in this.harvesters)
        {
            try
            {
                har.Broke();
            }
            catch 
            {
                reminder.Add(har);
            }
            
        }

        foreach (var h in reminder)
            this.harvesters.Remove(h);

        this.mode = mode;
        return string.Format(OutputMessages.ModeChanged, mode);
    }

    public string Produce()
    {
        //calculate needed energy
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == Modes.FullMode)
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == Modes.HalfMode)
            {
                neededEnergy += harvester.EnergyRequirement * 50 /  100;
            }
            else if (this.mode == Modes.EnergyMode)
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            //mine
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.OreOutput;
            }
        }

        //take the mode in mind
        if (this.mode == Modes.EnergyMode)
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.mode == Modes.HalfMode)
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;

        
        return string.Format(Constants.OreOutputToday, minedOres);
        
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
}

