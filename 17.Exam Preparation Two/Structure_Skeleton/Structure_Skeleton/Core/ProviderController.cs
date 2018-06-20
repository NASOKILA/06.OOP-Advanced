using System.Collections.Generic;
using System.Linq;

public class ProviderController : IProviderController
{
    private IEnergyRepository energyRepository;
    private IList<IProvider> providers;
    private IProviderFactory factory;

    public ProviderController(
        IEnergyRepository energyRepository, 
        IList<IProvider> providers, 
        IProviderFactory factory)
    {
        this.energyRepository = energyRepository;
        this.providers = providers;
        this.factory = factory;

        this.TotalEnergyProduced = 0;
    }

    public double TotalEnergyProduced { get; private set; }

    public IList<IProvider> Entities => this.providers;

    public string Register(IList<string> arguments)
    {
        var provider = this.factory.GenerateProvider(arguments);
        this.providers.Add(provider);
        return string.Format(Constants.SuccessfullRegistration, 
            provider.GetType().Name);
    }

    public string Produce()
    {
        double energyProduced = this.providers.Select(n => n.Produce()).Sum();
        this.energyRepository.StoreEnergy(energyProduced);
        this.TotalEnergyProduced += energyProduced;

        List<IProvider> reminder = new List<IProvider>();

        foreach (var provider in this.providers)
        {
            try
            {
                provider.Broke();
            }
            catch
            {
                reminder.Add(provider);
            }
        }

        foreach (var entity in reminder)
        {
            this.providers.Remove(entity);
        }

        return string.Format(Constants.EnergyOutputToday, energyProduced);
    }

    public string Repair(double val)
    {
        foreach (var provider in this.providers)
        {
            provider.Repair(val);
        }

        return string.Format(Constants.ProvidersRepaired, val);
    }
}