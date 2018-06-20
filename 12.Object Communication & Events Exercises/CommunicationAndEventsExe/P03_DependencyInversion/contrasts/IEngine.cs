namespace P03_DependencyInversion.contrasts
{
    public interface IEngine
    {
        void Run(PrimitiveCalculator calculator);
    }
}
