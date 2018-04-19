namespace Heroes.Models.Contracts
{
    public interface ITarget
    {
        bool IsDead { get; }

        void ReceiveDamage(int damage);
    }
}