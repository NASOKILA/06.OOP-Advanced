namespace P03_DependencyInversion
{
    using contrasts;

    public class SubtractionStrategy : IStrategy 
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
