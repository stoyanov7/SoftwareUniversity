namespace BoatRacingSimulator.Models.Contracts
{
    public interface IBoatEngine : IModelable
    {
        int Output { get; }
    }
}