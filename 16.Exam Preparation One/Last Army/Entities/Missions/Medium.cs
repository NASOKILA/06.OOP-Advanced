
public class Medium : Mission
{
    private const string name = "Capturing dangerous criminals";
    private const double enduranceRequired = 50;
    private const double wearLevelDecrement = 50;

    public Medium(double ScoreToComplete) 
        : base(ScoreToComplete)
    {}

    public override double EnduranceRequired => enduranceRequired;
    public override string Name => name;
    public override double WearLevelDecrement => wearLevelDecrement;
}

