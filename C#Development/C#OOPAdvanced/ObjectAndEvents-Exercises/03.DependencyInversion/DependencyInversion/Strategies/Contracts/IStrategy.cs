namespace DependencyInversion.Strategies.Contracts
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}