
public abstract class Mission : IMission
{

    protected Mission(double ScoreToComplete)
    {
        this.ScoreToComplete = ScoreToComplete;
    }

    public abstract double EnduranceRequired { get; }

    public double ScoreToComplete { get; }

    public abstract string Name { get; }

    public abstract double WearLevelDecrement { get; }
}

