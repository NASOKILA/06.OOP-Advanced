namespace P03_DependencyInversion
{
    using contrasts;

    public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }    
    }
}
