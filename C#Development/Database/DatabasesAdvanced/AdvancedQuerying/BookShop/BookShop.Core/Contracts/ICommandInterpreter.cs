namespace BookShop.Core.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] commandName);
    }
}