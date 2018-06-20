public class SolarProvider : Provider
{
    public SolarProvider(int ID, double energyOutput)
    : base(ID, energyOutput)
    {
        this.Durability += 500;
    }
}

