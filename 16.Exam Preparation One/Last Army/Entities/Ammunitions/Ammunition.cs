

public abstract class Ammunition : IAmmunition
{

    private const int wearLevelMultiplyer = 100;
    
    public Ammunition()
    {
        //Upon creation, each ammunition has a wear level equal to its weight * 100
        this.WearLevel = Weight * wearLevelMultiplyer; //wearLevel e = na Weight * 100
    }
    
    public string Name => this.GetType().Name;  //imeto na samiq klas

    public abstract double Weight { get; } //slagame go da e bstrakten za da moje da se prezapisva
    //zashtoto vsqko orujie shte ima razlichna tejest

    public double WearLevel { get; private set; } //slagame mu private set za da mojem da go setnem

    public void DecreaseWearLevel(double wearAmount)
    {
        //wear level decreases after each successful mission
        this.WearLevel -= wearAmount;
    }
}
