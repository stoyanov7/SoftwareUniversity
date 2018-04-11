namespace DependencyInversion.Strategies
{
    using Contracts;

    public class MultyplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand) => firstOperand * secondOperand;
    }
}