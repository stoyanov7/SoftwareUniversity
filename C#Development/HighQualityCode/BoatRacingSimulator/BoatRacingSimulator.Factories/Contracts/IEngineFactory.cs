namespace BoatRacingSimulator.Factories.Contracts
{
    using Enumerations;
    using Models.Contracts;

    public interface IEngineFactory
    {
        IBoatEngine CreateEngine(string model, int horsepower, int displacement, EngineType engineType);
    }
}