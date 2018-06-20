namespace P03_DependencyInversion
{
    using contrasts;

    public class PrimitiveCalculator
    {

        private IStrategy currentStrategy;

        public PrimitiveCalculator(IStrategy passedStrategy)
        {
            this.currentStrategy = passedStrategy;
        }

        public void changeStrategy(IStrategy passedStrategy)
        {
            this.currentStrategy = passedStrategy;
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            return currentStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}





