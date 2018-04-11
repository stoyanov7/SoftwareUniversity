namespace DependencyInversion.Strategies
{
    using Contracts;

    public class DivisionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand) => firstOperand / secondOperand;
    }
}