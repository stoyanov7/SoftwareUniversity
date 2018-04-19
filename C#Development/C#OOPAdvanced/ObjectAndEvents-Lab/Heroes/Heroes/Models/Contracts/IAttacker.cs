namespace Heroes.Models.Contracts
{
    public interface IAttacker
    {
        void Attack();

        void SetTarget(ITarget newTarget);
    }
}