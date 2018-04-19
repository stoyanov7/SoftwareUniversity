namespace BoatRacingSimulator.Factories
{
    using System;
    using Contracts;
    using Enumerations;
    using Models.Contracts;
    using Models.Engines;

    public class EngineFactory : IEngineFactory
    {
        public IBoatEngine CreateEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            switch (engineType)
            {
                case EngineType.Jet:
                    return new JetEngine(model, horsepower, displacement);
                case EngineType.Sterndrive:
                    return new SterndriveEngine(model, horsepower, displacement);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
