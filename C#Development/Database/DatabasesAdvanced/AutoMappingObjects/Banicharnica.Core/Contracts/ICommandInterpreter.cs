namespace Banicharnica.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] input);
    }
}