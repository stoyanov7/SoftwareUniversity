namespace BoatRacingSimulator.Database.Contracts
{
    using Models.Contracts;

    public interface IBoatSimulatorDatabase
    {
        IRepository<IBoat> Boats { get; }

        IRepository<IBoatEngine> Engines { get; }
    }
}