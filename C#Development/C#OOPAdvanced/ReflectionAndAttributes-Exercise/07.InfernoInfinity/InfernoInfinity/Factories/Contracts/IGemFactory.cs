namespace InfernoInfinity.Factories.Contracts
{
    using Models.Gems;

    public interface IGemFactory
    {
        IGem CreateGem(string args);
    }
}