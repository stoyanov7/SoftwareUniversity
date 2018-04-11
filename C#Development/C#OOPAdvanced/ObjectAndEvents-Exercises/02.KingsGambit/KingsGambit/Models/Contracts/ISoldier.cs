namespace KingsGambit.Models.Contracts
{
    public interface ISoldier : IKillable
    {
        string Name { get; }
    }
}