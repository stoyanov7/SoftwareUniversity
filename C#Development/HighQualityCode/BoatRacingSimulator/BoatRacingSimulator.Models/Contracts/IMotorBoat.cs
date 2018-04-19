namespace BoatRacingSimulator.Models.Contracts
{
    /// <summary>
    /// Defines the behaviour of the MotorBoat class.
    /// </summary>
    public interface IMotorBoat
    {
        IBoatEngine Engine { get; }
    }
}