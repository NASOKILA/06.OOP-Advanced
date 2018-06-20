using System;
using System.Text;

public abstract class Provider : IProvider
{
    private const double durability = 1000;

    protected Provider(int ID, double energyOutput)
    {
        this.ID = ID;
        this.EnergyOutput = energyOutput;
        this.Durability = durability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        //namalqva durabilitito sus 100 i ako e pod 0 hvurlq exeption za schupen provider
        this.Durability -= Constants.DurabilityDecrese;
        if (Durability < 0)
            throw new ArgumentException(string.Format(Constants.BrokenEntity, this.GetType().Name, this.ID));
    }

    public double Produce()
    {
        //prosto vushta kolko EnergyOutput sme suzdali
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        // uvelichava durabilitito sus podadenata stoinost
        this.Durability += val;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.GetType().Name);
        sb.AppendLine(string.Format(Constants.AppendDurability, this.Durability));
        return sb.ToString().Trim();
    }
}