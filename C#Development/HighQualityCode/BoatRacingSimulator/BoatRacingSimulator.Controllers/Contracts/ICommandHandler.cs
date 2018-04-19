namespace BoatRacingSimulator.Controllers.Contracts
{
    public interface ICommandHandler
    {
        string ExecuteCommand(string name, string[] parameters);
    }
}