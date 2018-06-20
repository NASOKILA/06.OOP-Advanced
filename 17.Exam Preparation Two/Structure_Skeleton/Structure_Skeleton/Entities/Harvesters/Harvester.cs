using System;
using System.Text;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const int DurabilityDecrese = 100;
 
    
    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = Constants.InitialDurability;
    }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public int ID { get; }

    public virtual double Durability { get; protected set; }

    public void Broke()
    {
        //namalqva durabiliti sus 100
        this.Durability -= Constants.DurabilityDecrese;

        if (Durability < 0)
        {
            throw new ArgumentException(string.Format(Constants.BrokenEntity, this.GetType().Name, this.ID));
        }
    }

    public double Produce()
    {
        //prosto vushta kolko OreOutput sme suzdali
        return this.OreOutput;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.GetType().Name);
        sb.AppendLine(string.Format(Constants.AppendDurability, this.Durability));
        return sb.ToString().Trim();
    }

}