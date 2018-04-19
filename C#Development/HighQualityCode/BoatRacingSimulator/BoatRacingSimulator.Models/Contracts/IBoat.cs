namespace BoatRacingSimulator.Models.Contracts
{
    /// <summary>
    /// Defines the behaviour of the Boat class.
    /// </summary>
    public interface IBoat : IModelable
    {
        int Weight { get; }

        double CalculateRaceSpeed(IRace race);
    }
}