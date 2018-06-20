
public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public EnergyRepository()
    {
        this.EnergyStored = 0;
    }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if (this.EnergyStored < energyNeeded)
            return false;

        this.EnergyStored -= energyNeeded;
        return true;
    }
}

