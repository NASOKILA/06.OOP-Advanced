

public abstract class Ammunition : IAmmunition
{
    private const int wearLevelMultiplyer = 100;
    
    public Ammunition()
    {
        this.WearLevel = Weight * wearLevelMultiplyer; 
    }
    
    public string Name => this.GetType().Name;  

    public abstract double Weight { get; } 

    public double WearLevel { get; private set; } 

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}
