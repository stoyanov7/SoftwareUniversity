namespace DependencyInversion.Controller
{
    using System.Collections.Generic;
    using Contracts;
    using Strategies;
    using Strategies.Contracts;

    public class PrimitiveCalculator : IPrimitiveCalculator
    {
        private IStrategy strategy;

        private readonly IDictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>()
        {
            {'+', new AdditionStrategy()},
            {'-', new SubtractionStrategy()},
            {'*', new MultyplicationStrategy()},
            {'/', new DivisionStrategy()}
        };

        public PrimitiveCalculator() => this.strategy = this.strategies['+'];

        public void ChangeStrategy(char @operator) => this.strategy = this.strategies[@operator];

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}