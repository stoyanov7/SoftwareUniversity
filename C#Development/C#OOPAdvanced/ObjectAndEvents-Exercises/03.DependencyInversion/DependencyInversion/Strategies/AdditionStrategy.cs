namespace DependencyInversion.Strategies
{
    using Contracts;

    public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand) => firstOperand + secondOperand;
    }
}