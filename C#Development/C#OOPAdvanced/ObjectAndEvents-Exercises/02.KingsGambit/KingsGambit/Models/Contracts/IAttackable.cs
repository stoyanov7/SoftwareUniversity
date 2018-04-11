namespace KingsGambit.Models.Contracts
{
    using System;

    public interface IAttackable
    {
        event EventHandler UnderAttack;

        void OnUnderAttack();
    }
}