namespace TeamBuilder.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] input);
    }
}