namespace DependencyInversion.Strategies
{
    using Contracts;

    public class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand) => firstOperand - secondOperand;
    }
}