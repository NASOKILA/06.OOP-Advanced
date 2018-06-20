public class PressureProvider : Provider
{
    private const double energyMultiplyer = 2;

    public PressureProvider(int ID, double energyOutput) 
        : base(ID, energyOutput)
    {
        this.Durability += 300;
        this.EnergyOutput *= energyMultiplyer;
    }

}

